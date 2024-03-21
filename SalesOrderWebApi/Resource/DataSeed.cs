using Microsoft.EntityFrameworkCore;
using SalesOrderWebApi.Entity;

namespace SalesOrderWebApi.Resource
{
    public static class DataSeed
    {
        private static Customer[] _customers = new Customer[]
            {
                new Customer
                {
                    Id = Guid.NewGuid().ToString(),
                    Address = "Jakarta",
                    CustomerName = "Cust Name A",
                    CustomerNo = "CS1",
                    CustomerType = CustomerType.Mrs,
                    Phone = "+11"
                },
                new Customer
                {
                    Id = Guid.NewGuid().ToString(),
                    Address = "Bogor",
                    CustomerName = "Cust Name B",
                    CustomerNo = "CS2",
                    CustomerType = CustomerType.Mr,
                    Phone = "+12"
                },
                new Customer
                {
                    Id = Guid.NewGuid().ToString(),
                    Address = "Surabaya",
                    CustomerName = "Cust Name C",
                    CustomerNo = "CS3",
                    CustomerType = CustomerType.Company,
                    Phone = "+13"
                },
                new Customer
                {
                    Id = Guid.NewGuid().ToString(),
                    Address = "Semarang",
                    CustomerName = "Cust Name D",
                    CustomerNo = "CS4",
                    CustomerType = CustomerType.Mrs,
                    Phone = "+14"
                },
                new Customer
                {
                    Id = Guid.NewGuid().ToString(),
                    Address = "Depok",
                    CustomerName = "Cust Name E",
                    CustomerNo = "CS5",
                    CustomerType = CustomerType.Mr,
                    Phone = "+15"
                },
            };

        private static ProductSparepart[] _product = new ProductSparepart[]
            {
                new ProductSparepart
                {
                    Id = Guid.NewGuid().ToString(),
                    Brand = "Brand1",
                    Code = "P00001",
                    COGS = 500,
                    Description = "Pencil",
                    Type = "PRO",
                    UOM = "PCS"
                },
                new ProductSparepart
                {
                    Id = Guid.NewGuid().ToString(),
                    Brand = "Brand2",
                    Code = "P00002",
                    COGS = 50000,
                    Description = "Table",
                    Type = "PRO",
                    UOM = "PCS"
                },
                new ProductSparepart
                {
                    Id = Guid.NewGuid().ToString(),
                    Brand = "Brand3",
                    Code = "P00003",
                    COGS = 9000,
                    Description = "Bolt",
                    Type = "SPA",
                    UOM = "Box"
                },
                new ProductSparepart
                {
                    Id = Guid.NewGuid().ToString(),
                    Brand = "Brand4",
                    Code = "P00004",
                    COGS = 1200000,
                    Description = "Shock Breaker",
                    Type = "SPA",
                    UOM = "PCS"
                },
                new ProductSparepart
                {
                    Id = Guid.NewGuid().ToString(),
                    Brand = "Brand5",
                    Code = "P00005",
                    COGS = 700000,
                    Description = "Tire",
                    Type = "SPA",
                    UOM = "PCS"
                }
            };

        private static MarketingArea[] _marketingAreas = new MarketingArea[]
            {
                new MarketingArea
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = "A001",
                    Description = "Area Sumatera"
                },
                new MarketingArea
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = "A002",
                    Description = "Area Jabodetabek"
                },
                new MarketingArea
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = "A003",
                    Description = "Area Jawa, Bali dan Indonesia Timur"
                }
            };

        private static Store[] _store = new Store[]
            {
                new Store
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = "S00001",
                    Address = "Jl Semeru",
                    MarketingAreaId = _marketingAreas[0].Id,
                    Description = "Medan",
                    Phone = "123456"
                },
                new Store
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = "S00002",
                    Address = "Jl Gajah",
                    MarketingAreaId = _marketingAreas[0].Id,
                    Description = "Palembang",
                    Phone = "123456"
                },
                new Store
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = "S00003",
                    Address = "Jl Sudirman",
                    MarketingAreaId = _marketingAreas[1].Id,
                    Description = "Jakarta",
                    Phone = "123456"
                },
                new Store
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = "S00004",
                    Address = "Jl Sudirman",
                    MarketingAreaId = _marketingAreas[2].Id,
                    Description = "Surabaya",
                    Phone = "123456"
                },
                new Store
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = "S00005",
                    Address = "Jl Dewa",
                    MarketingAreaId = _marketingAreas[2].Id,
                    Description = "Bali",
                    Phone = "123456"
                }
            };

        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(_customers);

            modelBuilder.Entity<MarketingArea>().HasData(_marketingAreas);

            modelBuilder.Entity<ProductSparepart>().HasData(_product);

            modelBuilder.Entity<Store>().HasData(_store);
        }
    }
}
