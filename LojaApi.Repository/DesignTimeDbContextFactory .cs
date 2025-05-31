using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Diagnostics.Metrics;

namespace LojaApi.Repository

{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            //optionsBuilder.UseSqlServer("Server=LojaDb;Database=MASTER;User Id=sa;Password=LojaDb123;");
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MASTER;User Id=sa;Password=LojaDb123;TrustServerCertificate=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
