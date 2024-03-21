using Microsoft.EntityFrameworkCore;
using SalesOrderWebApi.Entity;
using System;

namespace SalesOrderWebApi.Context
{
    public class QueryDbContext : DbContext
    {
        public QueryDbContext(DbContextOptions<QueryDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductSparepart> ProductSpareparts { get; set; }
        public DbSet<MarketingArea> MarketingAreas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
