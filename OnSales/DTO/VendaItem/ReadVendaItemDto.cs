namespace OnSales.DTO.VendaItem;

public class ReadVendaItemDto
{
    public Guid Id { get; set; }
    public Guid VendaId { get; set; }
    public virtual Guid ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public decimal Total { get; set; }
    public bool Ativo { get; set; }
    public Guid UltimoUsuarioId { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
}
