﻿using LegacySOAP.Models;
using System.Data.Entity;

namespace LegacySOAP.Data
{
    public class LegacyDbContext : DbContext
    {
        public LegacyDbContext() : base("Legacy")
        {
        }

        public LegacyDbContext(string connectionString):base(connectionString)
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