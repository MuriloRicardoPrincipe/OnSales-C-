using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnSales.DTO.VendaItem;
using OnSales.Share.Data.Data;
using OnSales.Share.Model.Model;

namespace OnSales.Repository;

public class VendaItemRepository : IVendaItemRepository
{
    private readonly OnSalesContext _context;
    private IMapper _mapper;

    public VendaItemRepository(OnSalesContext context, IMapper mapper, IVendaRepository vendaRepository, IProdutoRepository produtoRepository)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Criar(Guid userId, CriaAtualizaVendaItemDto dto)
    {
        var venda = await _context.Vendas.FirstOrDefaultAsync(p => p.Id == dto.VendaId);
        var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == dto.ProdutoId);
        var estoque = await _context.Estoques.FirstOrDefaultAsync(p => p.ProdutoId == dto.ProdutoId);

        if (!validaQuantidade(estoque.Quantidade, dto.Quantidade)) throw new Exception("Quantidade invalida, validar quantidade em estoque!");
        estoque.RetiradaEstoque(estoque.Quantidade, dto.Quantidade);

        var total = totalVendaItem(dto.Quantidade, produto.PrecoVenda);

        VendaItens vendaItens = new VendaItens(
            Guid.NewGuid(),
            userId,
            dto.VendaId,
            dto.ProdutoId,
            dto.Quantidade,
            total
        );


        await _context.VendaItens.AddAsync(vendaItens);
        await _context.SaveChangesAsync();


        var novoTotal = CalcularTotalVenda(venda);
        venda.AtualizaVendaTotal(userId, novoTotal);

        await _context.Vendas.AddAsync(venda);
        await _context.SaveChangesAsync();

    }

    public async Task<bool> Delete(Guid id)
    {
        var prod = await _context.VendaItens.FirstOrDefaultAsync(p => p.Id == id);

        if (prod == null)
            return false;

        _context.VendaItens.Remove(prod);

        await _context.SaveChangesAsync();

        return true;
    }

    public List<ReadVendaItemDto> GetAll()
    {
        return _mapper.Map<List<ReadVendaItemDto>>(_context.VendaItens.ToList());
    }

    public ReadVendaItemDto GetById(Guid id)
    {
        var prod = _mapper.Map<ReadVendaItemDto>(_context.VendaItens.FirstOrDefault(p => p.Id == id));
        if (prod == null)
        {
            return null;
        }

        return prod;
    }

    public async Task Update(Guid id, Guid userId, CriaAtualizaVendaItemDto dto)
    {
        var vendaItem = await _context.VendaItens
            .FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new KeyNotFoundException("Item de venda não encontrado.");

        var venda = await _context.Vendas.FirstOrDefaultAsync(p => p.Id == dto.VendaId)
            ?? throw new KeyNotFoundException("Venda não encontrada."); 
        var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == dto.ProdutoId)
            ?? throw new KeyNotFoundException("Venda não encontrada."); 
        var estoque = await _context.Estoques.FirstOrDefaultAsync(p => p.ProdutoId == dto.ProdutoId)
            ?? throw new KeyNotFoundException("Venda não encontrada.");

        estoque.DevolvendoEstoque(estoque.Quantidade, vendaItem.Quantidade);

        if (!validaQuantidade(estoque.Quantidade, dto.Quantidade)) throw new Exception("Quantidade invalida, validar quantidade em estoque!");

        estoque.RetiradaEstoque(estoque.Quantidade, dto.Quantidade);

        var total = totalVendaItem(dto.Quantidade, produto.PrecoVenda);

        vendaItem.AtualizarVendaItem(
            userId,
            dto.VendaId,
            dto.ProdutoId,
            dto.Quantidade,
            total
        );

        await _context.SaveChangesAsync();
    }

    private bool validaQuantidade(int quantidadeEstoque, int quantidadeVenda)
    {
        if (quantidadeEstoque < quantidadeVenda) return false;

        else return true;
    }

    private decimal totalVendaItem(int quantidade, decimal preco)
    {
        var total = preco * quantidade;
        return Math.Round(total, 2, MidpointRounding.AwayFromZero);
    }

    public decimal CalcularTotalVenda(Vendas venda)
    {
        var itens = _context.VendaItens.Where(vi => vi.VendaId == venda.Id).Sum(i => i.Total);
        return itens;
    }
}