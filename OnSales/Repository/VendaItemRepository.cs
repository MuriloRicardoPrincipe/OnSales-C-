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
        using var transaction = await _context.Database.BeginTransactionAsync();

        var venda = await _context.Vendas
            .FirstOrDefaultAsync(p => p.Id == dto.VendaId)
            ?? throw new KeyNotFoundException("Venda não encontrada.");

        var produto = await _context.Produtos
            .FirstOrDefaultAsync(p => p.Id == dto.ProdutoId)
            ?? throw new KeyNotFoundException("Produto não encontrado.");

        var estoque = await _context.Estoques
            .FirstOrDefaultAsync(p => p.ProdutoId == dto.ProdutoId)
            ?? throw new KeyNotFoundException("Estoque não encontrado.");

        // 🔥 Agora o estoque se valida sozinho
        estoque.Retirar(dto.Quantidade);

        var totalItem = Math.Round(produto.PrecoVenda * dto.Quantidade, 2, MidpointRounding.AwayFromZero);

        var vendaItem = new VendaItens(
            Guid.NewGuid(),
            userId,
            dto.VendaId,
            dto.ProdutoId,
            dto.Quantidade,
            totalItem
        );

        await _context.VendaItens.AddAsync(vendaItem);

        venda.AtualizaVendaTotal(userId, venda.Total + totalItem);

        await _context.SaveChangesAsync();
        await transaction.CommitAsync();
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
        using var transaction = await _context.Database.BeginTransactionAsync();

        var vendaItem = await _context.VendaItens
            .FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new KeyNotFoundException("Item de venda não encontrado.");

        var venda = await _context.Vendas
            .FirstOrDefaultAsync(p => p.Id == vendaItem.VendaId)
            ?? throw new KeyNotFoundException("Venda não encontrada.");

        var produtoNovo = await _context.Produtos
            .FirstOrDefaultAsync(p => p.Id == dto.ProdutoId)
            ?? throw new KeyNotFoundException("Produto não encontrado.");

        decimal totalAntigoItem = vendaItem.Total;

        if (dto.ProdutoId != vendaItem.ProdutoId)
        {
            var estoqueAntigo = await _context.Estoques
                .FirstAsync(p => p.ProdutoId == vendaItem.ProdutoId);

            var estoqueNovo = await _context.Estoques
                .FirstAsync(p => p.ProdutoId == dto.ProdutoId);

            estoqueAntigo.Devolver(vendaItem.Quantidade);
            estoqueNovo.Retirar(dto.Quantidade);
        }
        else
        {
            var estoque = await _context.Estoques
                .FirstAsync(p => p.ProdutoId == dto.ProdutoId);

            var diferenca = dto.Quantidade - vendaItem.Quantidade;

            if (diferenca > 0)
                estoque.Retirar(diferenca);
            else if (diferenca < 0)
                estoque.Devolver(Math.Abs(diferenca));
        }

        var novoTotalItem = Math.Round(produtoNovo.PrecoVenda * dto.Quantidade, 2, MidpointRounding.AwayFromZero);

        vendaItem.AtualizarVendaItem(
            userId,
            dto.VendaId,
            dto.ProdutoId,
            dto.Quantidade,
            novoTotalItem
        );

        var diferencaTotal = novoTotalItem - totalAntigoItem;
        venda.AtualizaVendaTotal(userId, venda.Total + diferencaTotal);

        await _context.SaveChangesAsync();
        await transaction.CommitAsync();
    }
}