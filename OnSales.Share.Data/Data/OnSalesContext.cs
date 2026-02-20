using Microsoft.EntityFrameworkCore;
using OnSales.Share.Model.Model;

namespace OnSales.Share.Data.Data;

public class OnSalesContext:DbContext
{
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Contatos> Contatos { get; set; }
    public DbSet<Enderecos> Enderecos { get; set; }
    public DbSet<Estoques> Estoques { get; set; }
    public DbSet<Produtos> Produtos { get; set; }
    public DbSet<Vendas> Vendas { get; set; }
    public DbSet<VendaItens> VendaItens { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OnSales;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;Application Intent=ReadWrite;MultiSubnetFailover=False";

    public OnSalesContext(DbContextOptions<OnSalesContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Clientes>(cliente =>
        {
            cliente.HasKey(c => c.Id);

            cliente.HasMany(c => c.EnderecosDeCliente)
                   .WithOne(e => e.Cliente)
                   .HasForeignKey(e => e.ClienteId)
                   .OnDelete(DeleteBehavior.Cascade);

            cliente.HasMany(c => c.ContatosDeCliente)
                   .WithOne(cn => cn.Cliente)
                   .HasForeignKey(cn => cn.ClienteId)
                   .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Enderecos>(endereco =>
        {
            endereco.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Contatos>(contato =>
        {
            contato.HasKey(c => c.Id);
        });

        modelBuilder.Entity<Estoques>(estoque =>
        {
            estoque.HasKey(c => c.Id);

            estoque.HasOne(c => c.Produto)
                   .WithOne(e => e.Estoques)
                   .HasForeignKey<Estoques>(e => e.ProdutoId)
                   .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<Vendas>(venda =>
        {
            venda.HasKey(v => v.Id);

            venda.HasMany(v => v.VendaEmItens)
                 .WithOne(i => i.Venda)
                 .HasForeignKey(i => i.VendaId)
                 .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<VendaItens>(item =>
        {
            item.HasKey(i => i.Id);

            item.HasOne(i => i.Produto)
                .WithMany(p => p.VendaItens)
                .HasForeignKey(i => i.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Produtos>(produto =>
        {
            produto.HasKey(p => p.Id);

        });
    }
}
