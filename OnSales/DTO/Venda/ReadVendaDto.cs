namespace OnSales.DTO.Venda;

public class ReadVendaDto
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public decimal Total { get; set; }
    public bool Ativo { get; set; }
    public Guid UltimoUsuarioId { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
}
