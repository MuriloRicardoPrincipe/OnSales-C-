using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnSales.DTO.Produto;
using OnSales.Share.Data.Data;
using OnSales.Share.Model.Model;

namespace OnSales.Repository;

public class ProdutoRepository : IProdutoRepository
{
    private readonly OnSalesContext _context;
    private IMapper _mapper;


    public ProdutoRepository(OnSalesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Criar(Guid userId , CriaAtualizaProdutoDto dto)
    {

        Produtos prod = new Produtos(
            Guid.NewGuid(),
            userId,
            dto.Nome,
            dto.Descricao,
            dto.PrecoVenda,
            dto.PrecoCusto
        );

        await _context.Produtos.AddAsync(prod);
        await _context.SaveChangesAsync();

    }

    public async Task<bool> Delete(Guid id)
    {
        var prod = await _context.Produtos
            .FirstOrDefaultAsync(p => p.Id == id);

        if (prod == null)
            return false;

        _context.Produtos.Remove(prod);

        await _context.SaveChangesAsync();

        return true;
    }

    public List<ReadProdutoDto> GetAll()
    {
        return _mapper.Map<List<ReadProdutoDto>>(_context.Produtos.ToList());
    }

    public ReadProdutoDto GetById(Guid id)
    {
        var prod = _mapper.Map<ReadProdutoDto>(_context.Produtos.FirstOrDefault(p => p.Id == id));
        if (prod == null)
        {
            return null;
        }

        return prod;
    }

    public async Task Update(Guid id, Guid userId, CriaAtualizaProdutoDto dto)
    {
        var prod = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new KeyNotFoundException("Produto não encontrado.");


        prod.AtualizacaoProduto(
            userId,
            dto.Nome,
            dto.Descricao,
            dto.PrecoVenda,
            dto.PrecoCusto
        );

        _context.Produtos.Update(prod);

        await _context.SaveChangesAsync();

    }
}
