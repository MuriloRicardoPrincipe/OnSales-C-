namespace OnSales.Share.Model.Model;

public class VendaItens :BaseEntity
{
    public virtual Vendas Venda { get; private set; }
    public Guid VendaId { get; private set; }
    public virtual Produtos Produto { get; private set; }
    public virtual Guid ProdutoId { get; private set; }
    public int Quantidade { get; private set; }
    public decimal Total { get; private set; }

    public VendaItens(Guid id, Guid userUpdateId, Guid vendaId, Guid ProdutoId, int quantidade, decimal total)
    {
        this.VendaId = vendaId;
        this.ProdutoId = ProdutoId;
        ValidaQuantidade(quantidade);
        this.Total = total;
        UserChageFile(userUpdateId);
        CriaData();
    }
    protected VendaItens() { }
    public void AtualizarVendaItem(Guid userUpdateId, Guid vendaId, Guid ProdutoId, int quantidade, decimal total)
    {
        this.VendaId = vendaId;
        this.ProdutoId = ProdutoId;
        ValidaQuantidade(quantidade);
        this.Total = total;
        UserChageFile(userUpdateId);
        AtualizarData();
    }

    private void ValidaQuantidade(int quantidade)
    {
        if(quantidade < 0) throw new ArgumentException("Quantidade inválida.");
        this.Quantidade = quantidade;
    }
}
