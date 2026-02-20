namespace OnSales.DTO.Estoque;

public class ReadEstoqueDto
{
    public Guid Id { get; set; }
    public Guid ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public bool Ativo { get; set; }
    public Guid UltimoUsuarioId { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
}
