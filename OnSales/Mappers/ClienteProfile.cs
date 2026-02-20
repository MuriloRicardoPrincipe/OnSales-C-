using AutoMapper;
using OnSales.DTO.Cliente;
using OnSales.Share.Model.Model;

namespace OnSales.Mappers;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<Clientes, ReadClienteDto>();
    }
}
