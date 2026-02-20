namespace OnSales.Share.Model.Model;

public class Contatos : BaseEntity
{
    public virtual Clientes Cliente {  get; private set; }
    public virtual Guid ClienteId { get; private set; }
    public string Telefone { get; private set; }
    public string Email { get; private set; }
    public string Celular { get; private set; }

    public Contatos(Guid id,Guid userUpdateId, Guid clienteId, string telefone, string email, string celular)
    {
        this.ClienteId = clienteId;
        this.Telefone = telefone;
        this.Email = email;
        this.Celular = celular;
        CriaData();
    }

    private Contatos() { }

    public void atualizarContato(Guid userUpdateId, Guid clienteId, string telefone, string email, string celular)
    {
        this.ClienteId = clienteId;
        this.Telefone = telefone;
        this.Email = email;
        this.Celular = celular;
        UserChageFile(userUpdateId);
        AtualizarData();
    }

}