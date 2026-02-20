using AutoMapper;
using OnSales.DTO.Contato;
using OnSales.Share.Model.Model;

namespace OnSales.Mappers;

public class ContatoProfile : Profile
{
    public ContatoProfile()
    {
        CreateMap<Contatos, ReadContatoDto>();
    }
}
