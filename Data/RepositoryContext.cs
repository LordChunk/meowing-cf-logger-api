using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class RepositoryContext : DbContext
    {
        // DbSets
        public DbSet<CfHttpHeader> CfHttpHeaders { get; set; }
        public DbSet<HttpHeader> HttpHeaders { get; set; }
        public DbSet<HttpRequest> HttpRequests { get; set; }
        public DbSet<TlsClientAuth> TlsClientAuths { get; set; }
        public DbSet<TlsExportedAuthenticator> TlsExportedAuthenticators { get; set; }

        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MeowingCfLogger;Trusted_Connection=True;");
                optionsBuilder.UseMySQL(
                    @"server=192.168.1.10;database=meowingcflogger;uid=meowingcflogger;pwd=D&dz9Nv*#qQF4dxM&g#3iVUP5NXog&%xi8^Kujmm8VCzPsaMZJrX&cue$UCnJq^^Gf"
                    );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set one to many relationship between HttpHeader and HttpRequest
            modelBuilder.Entity<HttpHeader>()
                .HasOne(h => h.HttpRequest)
                .WithMany(r => r.Headers)
                .HasForeignKey(h => h.HttpRequestId);

            // Set composite key for HttpHeader
            modelBuilder.Entity<HttpHeader>()
                .HasKey(r => new {r.Header, r.HttpRequestId});
        }
    }
}