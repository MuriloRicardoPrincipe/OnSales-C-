using OnSales.DTO.Produto;

namespace OnSales.Repository;

public interface IProdutoRepository:IRepository<CriaAtualizaProdutoDto, ReadProdutoDto>
{

}
