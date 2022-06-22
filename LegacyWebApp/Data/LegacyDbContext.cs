using LegacyWebApp.Models;
using System.Data.Entity;

namespace LegacyWebApp.Data
{
    public class LegacyDbContext: DbContext
    {
        public LegacyDbContext():base("Legacy")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().ToTable("Products");
        }

        public DbSet<Product> Products { get; set; }
    }
}