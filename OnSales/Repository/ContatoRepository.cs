using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnSales.DTO.Contato;
using OnSales.Share.Data.Data;
using OnSales.Share.Model.Model;

namespace OnSales.Repository;

public class ContatoRepository : IContatoRepository
{
    private readonly OnSalesContext _context;
    private IMapper _mapper;


    public ContatoRepository(OnSalesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Criar(Guid userId, CriaAtualizaContatoDto dto)
    {

        Contatos prod = new Contatos(
            Guid.NewGuid(),
            userId,
            dto.ClienteId,
            dto.Telefone,
            dto.Email,
            dto.Celular
        );

        await _context.Contatos.AddAsync(prod);
        await _context.SaveChangesAsync();

    }

    public async Task<bool> Delete(Guid id)
    {
        var prod = await _context.Contatos
            .FirstOrDefaultAsync(p => p.Id == id);

        if (prod == null)
            return false;

        _context.Contatos.Remove(prod);

        await _context.SaveChangesAsync();

        return true;
    }

    public List<ReadContatoDto> GetAll()
    {
        return _mapper.Map<List<ReadContatoDto>>(_context.Contatos.ToList());
    }

    public ReadContatoDto GetById(Guid id)
    {
        var prod = _mapper.Map<ReadContatoDto>(_context.Contatos.FirstOrDefault(p => p.Id == id));
        if (prod == null)
        {
            return null;
        }

        return prod;
    }

    public async Task Update(Guid id, Guid userId, CriaAtualizaContatoDto dto)
    {
        var prod = await _context.Contatos.FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new KeyNotFoundException("Contato não encontrado.");

        var cliente = await _context.Clientes.FirstOrDefaultAsync(p => p.Id == dto.ClienteId)
            ?? throw new KeyNotFoundException("Cliente não encontrado.");

        prod.atualizarContato(
            userId,
            dto.ClienteId,
            dto.Telefone,
            dto.Email,
            dto.Celular
        );

        _context.Contatos.Update(prod);

        await _context.SaveChangesAsync();
    }
}