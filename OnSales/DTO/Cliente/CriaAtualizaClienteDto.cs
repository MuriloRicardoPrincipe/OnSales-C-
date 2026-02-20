using OnSales.Share.Model.Model;

namespace OnSales.DTO.Cliente;

public class CriaAtualizaClienteDto
{
    public required string Nome { get; set; }
    public required TipoDocumento TipoDeDocumento { get; set; }
    public required string Documento { get; set; }
}
