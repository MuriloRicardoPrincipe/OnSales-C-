namespace OnSales.DTO.Contato;

public class ReadContatoDto
{
    public Guid Id { get; set; }
    public virtual Guid ClienteId { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Celular { get; set; }
    public bool Ativo { get; set; }
    public Guid UltimoUsuarioId { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
}
