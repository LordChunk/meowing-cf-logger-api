using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationContext : DbContext
    {
        // DbSets
        public DbSet<CfHttpHeader> CfHttpHeaders { get; set; }
        public DbSet<HttpHeader> HttpHeaders { get; set; }
        public DbSet<HttpRequest> HttpRequests { get; set; }
        public DbSet<HttpRequestLog> HttpRequestLog { get; set; }
        public DbSet<TlsClientAuth> TlsClientAuths { get; set; }
        public DbSet<TlsExportedAuthenticator> TlsExportedAuthenticators { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //}

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

            // Add DateTime value to HttpRequestLog
            modelBuilder.Entity<HttpRequestLog>()
                .Property(l => l.CreatedAt)
                .HasDefaultValueSql("NOW()");
        }
    }
}