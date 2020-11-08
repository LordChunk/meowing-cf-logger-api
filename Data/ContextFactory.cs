using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data
{
    class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).ToString())
            .AddJsonFile("API/appsettings.json")
            .Build();

        public ApplicationContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseMySQL(Configuration["MySQLConnectionStrings:Default"]);

            return new ApplicationContext(builder.Options);
        }
    }
}
