using AutoMapper;
using OnSales.DTO.Produto;
using OnSales.Share.Model.Model;

namespace OnSales.Mappers;

public class ProdutoProfile: Profile
{
    public ProdutoProfile() 
    {
        CreateMap<Produtos, ReadProdutoDto>();
    }
}
