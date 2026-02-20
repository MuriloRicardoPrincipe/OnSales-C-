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

    private Estoques() { }
    public void AtualizacaoEstoque(Guid userUpdateId, Guid produtoId, int quantidade)
    {
        this.ProdutoId = produtoId;
        this.Quantidade = quantidade;
        UserChageFile(userUpdateId);
        AtualizarData();
    }

    public void RetiradaEstoque(int quantidadeEstoque, int quantidadeSolicitado)
    {
        this.Quantidade = quantidadeEstoque - quantidadeSolicitado;
    }

    public void DevolvendoEstoque(int quantidadeEstoque, int quantidadeDevolvida)
    {
        this.Quantidade = quantidadeEstoque + quantidadeDevolvida;
    }
}
