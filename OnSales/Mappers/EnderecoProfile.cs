using AutoMapper;
using OnSales.DTO.Endereco;
using OnSales.Share.Model.Model;

namespace OnSales.Mappers;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<Enderecos, ReadEnderecoDto>();
    }
}
