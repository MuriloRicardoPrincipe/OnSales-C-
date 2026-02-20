using OnSales.Share.Model.Model;

namespace OnSales.DTO.Contato;

public class CriaAtualizaContatoDto
{
    public required virtual Guid ClienteId { get; set; }
    public required string Telefone { get; set; }
    public required string Email { get; set; }
    public required string Celular { get; set; }
}
