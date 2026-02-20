namespace OnSales.DTO.Produto;

public class CriaAtualizaProdutoDto
{
    public required string Nome { get; set; }
    public required string Descricao { get; set; }
    public required decimal PrecoVenda { get; set; }
    public required decimal PrecoCusto { get; set; }
}
