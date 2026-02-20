namespace OnSales.DTO.Estoque;

public class CriaAtualizaEstoqueDto
{
    public required Guid ProdutoId { get; set; }
    public required int Quantidade { get; set; }
}
