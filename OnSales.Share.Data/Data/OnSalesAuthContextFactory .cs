using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace OnSales.Share.Data.Data;

internal class OnSalesAuthContextFactory : IDesignTimeDbContextFactory<OnSalesAuthContext>
{
    OnSalesAuthContext IDesignTimeDbContextFactory<OnSalesAuthContext>.CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<OnSalesAuthContext>();
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OnSales;Integrated Security=True;");

        return new OnSalesAuthContext(optionsBuilder.Options);
    }
}
