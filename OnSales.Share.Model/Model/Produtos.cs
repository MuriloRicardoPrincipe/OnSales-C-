namespace OnSales.Share.Model.Model
{
    public class Produtos : BaseEntity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public decimal PrecoCusto { get; private set; }
        public virtual Estoques Estoques { get; private set; }
        public virtual ICollection <VendaItens> VendaItens { get; private set; } = new List<VendaItens>();
        public Produtos(Guid id,Guid userUpdateId, string nome, string descricao, decimal precoVenda, decimal precoCusto) : base(id)
        {
            Nome = nome;
            Descricao = descricao;
            PrecoVenda = precoVenda;
            PrecoCusto = precoCusto;
            UserChageFile(userUpdateId);
            CriaData();
        }
        protected Produtos() { }

        public void AtualizacaoProduto(Guid userUpdateId, string nome, string descricao, decimal precoVenda, decimal precoCusto)
        {
            Nome = nome;
            Descricao = descricao;
            PrecoVenda = precoVenda;
            PrecoCusto = precoCusto;
            UserChageFile(userUpdateId);
            AtualizarData();
        }
    }
}
