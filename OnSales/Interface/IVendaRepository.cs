using OnSales.DTO.Venda;
using OnSales.Share.Model.Model;

namespace OnSales.Repository;

public interface IVendaRepository:IRepository<CriaAtualizaVendaDto, ReadVendaDto>
{
}
