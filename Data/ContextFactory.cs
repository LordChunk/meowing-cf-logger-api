using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data
{
    class ContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    { 

        public RepositoryContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<RepositoryContext>();

            return new RepositoryContext(builder.Options);
        }
    }
}
