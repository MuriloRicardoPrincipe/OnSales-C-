using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnSales.DTO.Endereco;
using OnSales.Share.Data.Data;
using OnSales.Share.Model.Model;

namespace OnSales.Repository;

public class EnderecoRepository : IEnderecoRepository
{
    private readonly OnSalesContext _context;
    private IMapper _mapper;


    public EnderecoRepository(OnSalesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Criar(Guid userId, CriaAtualizaEnderecoDto dto)
    {

        Enderecos prod = new Enderecos(
            Guid.NewGuid(),
            userId,
            dto.Rua,
            dto.Numero,
            dto.Complemento,
            dto.Bairro,
            dto.Cidade,
            dto.Estado,
            dto.Cep,
            dto.ClientId
        );

        await _context.Enderecos.AddAsync(prod);
        await _context.SaveChangesAsync();

    }

    public async Task<bool> Delete(Guid id)
    {
        var prod = await _context.Enderecos
            .FirstOrDefaultAsync(p => p.Id == id);

        if (prod == null)
            return false;

        _context.Enderecos.Remove(prod);

        await _context.SaveChangesAsync();

        return true;
    }

    public List<ReadEnderecoDto> GetAll()
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());
    }

    public ReadEnderecoDto GetById(Guid id)
    {
        var prod = _mapper.Map<ReadEnderecoDto>(_context.Enderecos.FirstOrDefault(p => p.Id == id));
        if (prod == null)
        {
            return null;
        }

        return prod;
    }

    public async Task Update(Guid id, Guid userId, CriaAtualizaEnderecoDto dto)
    {
        var prod = await _context.Enderecos.FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new KeyNotFoundException("Endereço não encontrado.");

        var cliente = await _context.Enderecos.FirstOrDefaultAsync(p => p.Id == dto.ClientId)
            ?? throw new KeyNotFoundException("Cliente não encontrado.");

        prod.AtualizacaoEndereco(
            userId,
            dto.Rua,
            dto.Numero,
            dto.Complemento,
            dto.Bairro,
            dto.Cidade,
            dto.Estado,
            dto.Cep,
            dto.ClientId
        );

        _context.Enderecos.Update(prod);

        await _context.SaveChangesAsync();
    }
}