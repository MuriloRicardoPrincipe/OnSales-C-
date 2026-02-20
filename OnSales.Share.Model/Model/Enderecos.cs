namespace OnSales.Share.Model.Model;

public class Enderecos :BaseEntity
{
    public virtual Clientes Cliente {  get; private set; }
    public Guid ClienteId { get; private set; }
    public string Rua { get; private set; }
    public string Numero { get; private set; }
    public string Complemento { get; private set; }
    public string Bairro { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }
    public string Cep { get; private set; }

    public Enderecos(Guid id, Guid userUpdateId,string rua, string numero, string complemento, string bairro, string cidade, string estado, string cep, Guid clienteId)
    {
        this.Rua = rua;
        this.Numero = numero;
        this.Complemento = complemento;
        this.Bairro = bairro;
        this.Cidade = cidade;
        this.Estado = estado;
        this.Cep = cep;
        this.ClienteId = clienteId;
        UserChageFile(userUpdateId);
        CriaData();
    }

    private Enderecos() { }
    public void AtualizacaoEndereco(Guid userUpdateId, string rua, string numero, string complemento, string bairro, string cidade, string estado, string cep, Guid clienteId) 
    {
        this.Rua = rua;
        this.Numero = numero;
        this.Complemento = complemento;
        this.Bairro = bairro;
        this.Cidade = cidade;
        this.Estado = estado;
        this.Cep = cep;
        this.ClienteId = clienteId;
        UserChageFile(userUpdateId);
        AtualizarData();

    }
}
