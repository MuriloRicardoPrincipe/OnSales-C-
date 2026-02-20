using OnSales.DTO.VendaItem;
using OnSales.Share.Model.Model;

namespace OnSales.Repository;

public interface IVendaItemRepository:IRepository<CriaAtualizaVendaItemDto, ReadVendaItemDto>
{
}
