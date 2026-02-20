using AutoMapper;
using OnSales.DTO.Venda;
using OnSales.Share.Model.Model;

namespace OnSales.Mappers;

public class VendasProfile : Profile
{
    public VendasProfile()
    {
        CreateMap<Vendas, ReadVendaDto>();
    }
}
