using Microsoft.EntityFrameworkCore;
using NextWebApp.Models;

namespace NextWebApp.Data
{
    public class NextDbContext : DbContext
    {
        public NextDbContext(DbContextOptions<NextDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("Products");
        }

        public DbSet<Product> Products { get; set; }

    }
}
