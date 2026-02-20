using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnSales.DTO.Estoque;
using OnSales.Share.Data.Data;
using OnSales.Share.Model.Model;

namespace OnSales.Repository;

public class EstoqueRepository : IEstoqueRepository
{
    private readonly OnSalesContext _context;
    private IMapper _mapper;


    public EstoqueRepository(OnSalesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Criar(Guid userId, CriaAtualizaEstoqueDto dto)
    {

        Estoques prod = new Estoques(
            Guid.NewGuid(),
            userId,
            dto.ProdutoId,
            dto.Quantidade
        );

        await _context.Estoques.AddAsync(prod);
        await _context.SaveChangesAsync();

    }

    public async Task<bool> Delete(Guid id)
    {
        var prod = await _context.Estoques
            .FirstOrDefaultAsync(p => p.Id == id);

        if (prod == null)
            return false;

        _context.Estoques.Remove(prod);

        await _context.SaveChangesAsync();

        return true;
    }

    public List<ReadEstoqueDto> GetAll()
    {
        return _mapper.Map<List<ReadEstoqueDto>>(_context.Estoques.ToList());
    }

    public ReadEstoqueDto GetById(Guid id)
    {
        var prod = _mapper.Map<ReadEstoqueDto>(_context.Estoques.FirstOrDefault(p => p.Id == id));
        if (prod == null)
        {
            return null;
        }

        return prod;
    }

    public async Task Update(Guid id, Guid userId, CriaAtualizaEstoqueDto dto)
    {
        var prod = await _context.Estoques
            .FirstOrDefaultAsync(p => p.Id == id)
                ?? throw new KeyNotFoundException("Estoque não encontrado.");

        var produtoExiste = await _context.Produtos
            .AnyAsync(p => p.Id == dto.ProdutoId);

        if (!produtoExiste)
            throw new KeyNotFoundException("Produto não encontrado.");

        prod.AtualizacaoEstoque(
            userId,
            dto.ProdutoId,
            dto.Quantidade
        );

        _context.Estoques.Update(prod);

        await _context.SaveChangesAsync();
    }
}