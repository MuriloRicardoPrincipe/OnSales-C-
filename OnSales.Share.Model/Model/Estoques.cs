namespace OnSales.Share.Model.Model;

public class Estoques : BaseEntity
{
    public virtual Produtos Produto { get; private set; }
    public Guid ProdutoId { get; private set; }
    public int Quantidade { get; private set; }

    public Estoques(Guid id, Guid userUpdateId, Guid produtoId, int quantidade)
    {
        this.ProdutoId = produtoId;
        this.Quantidade = quantidade;
        UserChageFile(userUpdateId);
        CriaData();
    }

    protected Estoques() { }
    public void AtualizacaoEstoque(Guid userUpdateId, Guid produtoId, int quantidade)
    {
        this.ProdutoId = produtoId;
        this.Quantidade = quantidade;
        UserChageFile(userUpdateId);
        AtualizarData();
    }

    public void Retirar(int quantidadeSolicitada)
    {
        if (quantidadeSolicitada <= 0)
            throw new ArgumentException("Quantidade inválida.");

        if (Quantidade < quantidadeSolicitada)
            throw new InvalidOperationException("Estoque insuficiente.");

        Quantidade -= quantidadeSolicitada;
    }

    public void Devolver(int quantidadeDevolvida)
    {
        if (quantidadeDevolvida <= 0)
            throw new ArgumentException("Quantidade inválida.");

        Quantidade += quantidadeDevolvida;
    }
}
