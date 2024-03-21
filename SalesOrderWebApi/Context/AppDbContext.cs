using Microsoft.EntityFrameworkCore;
using SalesOrderWebApi.Entity;
using SalesOrderWebApi.Resource;

namespace SalesOrderWebApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductSparepart> ProductSpareparts { get; set; }
        public DbSet<MarketingArea> MarketingAreas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed data
            modelBuilder.SeedData();
        }
    }
}
