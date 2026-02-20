using AutoMapper;
using OnSales.DTO.VendaItem;
using OnSales.Share.Model.Model;

namespace OnSales.Mappers;

public class VendasItensProfile : Profile
{
    public VendasItensProfile()
    {
        CreateMap<VendaItens, ReadVendaItemDto>();
    }
}
