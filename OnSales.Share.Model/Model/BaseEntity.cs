namespace OnSales.Share.Model.Model;

public class BaseEntity
{
    public Guid Id { get; private set; }
    public bool Ativo { get; private set; }
    public Guid UltimoUsuarioId { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime DataAtualizacao { get; private set; }
    protected BaseEntity(Guid id)
    {
        Id = id;
        Ativo = true;
        DataCriacao = DateTime.UtcNow;
        DataAtualizacao = DateTime.UtcNow;
    }
    protected BaseEntity() { }

    public void CriaData()
    {
        DataCriacao = DateTime.UtcNow;
    }

    public void AtualizarData()
    {
        DataAtualizacao = DateTime.UtcNow;
    }

    public void UserChageFile(Guid ultimoUsuarioId)
    {
        this.UltimoUsuarioId = ultimoUsuarioId;
    }

    public void Ativar()
    {
        if (Ativo)
            return;

        Ativo = true;
        AtualizarData();
    }

    public void Desativar()
    {
        if (!Ativo)
            return;

        Ativo = false;
        AtualizarData();
    }

}
