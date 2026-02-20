using OnSales.Share.Model.Model;

namespace OnSales.DTO.Cliente;

public class ReadClienteDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public TipoDocumento TipoDeDocumento { get; set; }
    public string Documento { get; set; }
    public bool Ativo { get; set; }
    public Guid UltimoUsuarioId { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
}
