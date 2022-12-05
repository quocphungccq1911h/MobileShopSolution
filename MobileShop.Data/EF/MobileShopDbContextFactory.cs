using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MobileShop.Data.EF
{
    public class MobileShopDbContextFactory : IDesignTimeDbContextFactory<MobileShopDbContext>
    {
        public MobileShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("MobileShopSolutionDb");

            var optionBuilder = new DbContextOptionsBuilder<MobileShopDbContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new MobileShopDbContext(optionBuilder.Options);
        }
    }
}
