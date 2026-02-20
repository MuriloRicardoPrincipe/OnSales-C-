using OnSales.DTO.Estoque;
using OnSales.Share.Model.Model;

namespace OnSales.Repository;

public interface IEstoqueRepository:IRepository<CriaAtualizaEstoqueDto, ReadEstoqueDto>
{
}
