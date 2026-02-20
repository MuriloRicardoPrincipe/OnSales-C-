using AutoMapper;
using OnSales.DTO.Estoque;
using OnSales.Share.Model.Model;

namespace OnSales.Mappers;

public class EstoqueProfile : Profile
{
    public EstoqueProfile()
    {
        CreateMap<Estoques, ReadEstoqueDto>();
    }
}
