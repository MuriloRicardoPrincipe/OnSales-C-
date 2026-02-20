using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnSales.DTO.Venda;
using OnSales.Share.Data.Data;
using OnSales.Share.Model.Model;

namespace OnSales.Repository;

public class VendaRepository : IVendaRepository
{
    private readonly OnSalesContext _context;
    private IMapper _mapper;


    public VendaRepository(OnSalesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Criar(Guid userId, CriaAtualizaVendaDto dto)
    {

        Vendas prod = new Vendas(
            Guid.NewGuid(),
            userId,
            dto.ClienteId
        );

        await _context.Vendas.AddAsync(prod);
        await _context.SaveChangesAsync();

    }

    public async Task<bool> Delete(Guid id)
    {
        var prod = await _context.Vendas
            .FirstOrDefaultAsync(p => p.Id == id);

        if (prod == null)
            return false;

        _context.Vendas.Remove(prod);

        await _context.SaveChangesAsync();

        return true;
    }

    public List<ReadVendaDto> GetAll()
    {
        return _mapper.Map<List<ReadVendaDto>>(_context.Vendas.ToList());
    }

    public ReadVendaDto GetById(Guid id)
    {
        var prod = _mapper.Map<ReadVendaDto>(_context.Vendas.FirstOrDefault(p => p.Id == id));
        if (prod == null)
        {
            return null;
        }

        return prod;
    }

    public async Task Update(Guid id, Guid userId, CriaAtualizaVendaDto dto)
    {
        var venda = await _context.Vendas.FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new KeyNotFoundException("Venda não encontrado.");

        var cliente = await _context.Vendas.FirstOrDefaultAsync(p => p.Id == dto.ClienteId)
            ?? throw new KeyNotFoundException("Venda não encontrado.");

        venda.AtualizacaoVenda(
            userId,
             dto.ClienteId
        );

        _context.Vendas.Update(venda);

        await _context.SaveChangesAsync();
    }
}