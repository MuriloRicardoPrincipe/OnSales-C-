using OnSales.DTO.Endereco;
using OnSales.Share.Model.Model;

namespace OnSales.Repository;

public interface IEnderecoRepository:IRepository<CriaAtualizaEnderecoDto, ReadEnderecoDto>
{
}
