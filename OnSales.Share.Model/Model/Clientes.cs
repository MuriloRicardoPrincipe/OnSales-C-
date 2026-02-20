namespace OnSales.Share.Model.Model;

public class Clientes : BaseEntity
{
    public string Nome { get; private set; }
    public TipoDocumento TipoDeDocumento { get; private set; }
    public string Documento { get; private set; }
    public virtual ICollection<Contatos> ContatosDeCliente { get; private set; } = new List<Contatos>();
    public virtual ICollection<Enderecos> EnderecosDeCliente { get; private set; } = new List<Enderecos>();

    public Clientes(Guid id, Guid userUpdateId, string nome, TipoDocumento tipoDocumento, string documento)
    {
        this.Nome = nome;
        this.TipoDeDocumento = tipoDocumento;
        this.Documento = documento;
        UserChageFile(userUpdateId);
        CriaData();
    }

    private Clientes() { }

    public void AtualizacaoCliente(Guid userUpdateId, string nome, TipoDocumento tipoDocumento, string documento)
    {
        this.Nome = nome;
        this.TipoDeDocumento = tipoDocumento;
        this.Documento = documento;
        UserChageFile(userUpdateId);
        AtualizarData();
    }

}