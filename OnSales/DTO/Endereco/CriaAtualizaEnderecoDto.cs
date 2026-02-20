using OnSales.Share.Model.Model;

namespace OnSales.DTO.Endereco;

public class CriaAtualizaEnderecoDto
{
    public required Guid ClientId { get; set; }
    public required string Rua { get; set; }
    public required string Numero { get; set; }
    public required string Complemento { get; set; }
    public required string Bairro { get; set; }
    public required string Cidade { get; set; }
    public required string Estado { get; set; }
    public required string Cep { get; set; }
}
