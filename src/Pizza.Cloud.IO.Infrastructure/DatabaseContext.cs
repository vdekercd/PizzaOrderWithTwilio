using Microsoft.EntityFrameworkCore;
using Pizza.Cloud.IO.Domain;
using Pizza.Cloud.IO.Domain.Models;
using System;

namespace Pizza.Cloud.IO.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Domain.Models.Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }
    }
}
