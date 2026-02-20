using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnSales.Share.Data.Model;

namespace OnSales.Share.Data.Data;

public class OnSalesAuthContext : IdentityDbContext<PersonAccess, ProfileAccess, Guid>
{
    public OnSalesAuthContext(DbContextOptions<OnSalesAuthContext> options) : base(options) { }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CustomerAccountsSales;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;Application Intent=ReadWrite;MultiSubnetFailover=False";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        optionsBuilder.UseSqlServer(connectionString);
    }
}
