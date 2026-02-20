using OnSales.DTO.Cliente;
using OnSales.Share.Model.Model;

namespace OnSales.Repository;

public interface IClienteRepository: IRepository<CriaAtualizaClienteDto, ReadClienteDto>
{
}
