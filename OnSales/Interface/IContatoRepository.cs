using OnSales.DTO.Contato;
using OnSales.Share.Model.Model;

namespace OnSales.Repository;
public interface IContatoRepository:IRepository<CriaAtualizaContatoDto, ReadContatoDto>
{
}
