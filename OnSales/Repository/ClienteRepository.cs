using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnSales.DTO.Cliente;
using OnSales.Share.Data.Data;
using OnSales.Share.Model.Model;

namespace OnSales.Repository;

public class ClienteRepository : IClienteRepository
{
    private readonly OnSalesContext _context;
    private IMapper _mapper;


    public ClienteRepository(OnSalesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Criar(Guid userId, CriaAtualizaClienteDto dto)
    {

        Clientes prod = new Clientes(
            Guid.NewGuid(),
            userId,
            dto.Nome,
            dto.TipoDeDocumento,
            dto.Documento
        );

        await _context.Clientes.AddAsync(prod);
        await _context.SaveChangesAsync();

    }

    public async Task<bool> Delete(Guid id)
    {
        var prod = await _context.Clientes
            .FirstOrDefaultAsync(p => p.Id == id);

        if (prod == null)
            return false;

        _context.Clientes.Remove(prod);

        await _context.SaveChangesAsync();

        return true;
    }

    public List<ReadClienteDto> GetAll()
    {
        return _mapper.Map<List<ReadClienteDto>>(_context.Clientes.ToList());
    }

    public ReadClienteDto GetById(Guid id)
    {
        var prod = _mapper.Map<ReadClienteDto>(_context.Clientes.FirstOrDefault(p => p.Id == id));
        if (prod == null)
        {
            return null;
        }

        return prod;
    }

    public async Task Update(Guid id, Guid userId, CriaAtualizaClienteDto dto)
    {
        var prod = await _context.Clientes.FirstOrDefaultAsync(p => p.Id == id) 
            ?? throw new KeyNotFoundException("Cliente não encontrado.");

        prod.AtualizacaoCliente(
            userId,
            dto.Nome,
            dto.TipoDeDocumento,
            dto.Documento
        );

        _context.Clientes.Update(prod);

        await _context.SaveChangesAsync();
    }
}