using System;
using System.IO;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace Tests
{
    public class DatabaseFixture
    {
        public readonly ApplicationContext Context;
        public readonly RepositoryWrapper RepositoryWrapper;

        public readonly IConfiguration Configuration;

        public DatabaseFixture()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile(Directory.GetCurrentDirectory() + "../../../../../API/appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var dbOptionsBuilder = new DbContextOptionsBuilder();
            dbOptionsBuilder.UseMySQL(Configuration["MySQLConnectionStrings:Test"]);

            Context = new ApplicationContext(dbOptionsBuilder.Options);

            Context.Database.EnsureCreated();
            var dbCreated = ((RelationalDatabaseCreator) Context.GetService<IDatabaseCreator>()).Exists();

            if (!dbCreated)
                throw new DbUpdateException("Database does not exist and could not be created.");

            RepositoryWrapper = new RepositoryWrapper(Context);
        }
    }
}