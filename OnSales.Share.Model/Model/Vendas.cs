namespace OnSales.Share.Model.Model;

public class Vendas : BaseEntity
{
    public virtual Clientes Cliente { get; private set; }
    public Guid ClienteId { get; private set; }
    public virtual ICollection<VendaItens> VendaEmItens { get; private set; } = new List<VendaItens>();
    public decimal Total { get; private set; }


    public Vendas(Guid id, Guid userUpdateId,Guid clienteId)
    {
        this.ClienteId = clienteId;
        this.Total = 0;
        UserChageFile(userUpdateId);
        CriaData();
    }
    private Vendas() { }

    public void AtualizacaoVenda(Guid userUpdateId, Guid clienteId)
    {
        this.ClienteId = clienteId;
        UserChageFile(userUpdateId);
    }

    public void AtualizaVendaTotal(Guid userUpdateId, decimal total)
    {
        this.Total = total;
        UserChageFile(userUpdateId);
    }
}
