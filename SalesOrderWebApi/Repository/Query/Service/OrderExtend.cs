using Microsoft.EntityFrameworkCore;
using SalesOrderWebApi.Context;
using SalesOrderWebApi.Entity;
using SalesOrderWebApi.Repository.Query.Interface;
using SalesOrderWebApi.Resource;

namespace SalesOrderWebApi.Repository.Query.Service
{
    public class OrderExtend : IOrderExtend
    {
        private readonly QueryDbContext _context;

        public OrderExtend(QueryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders
                            .Include(c => c.Customer)
                            .Include(c => c.Store)
                            .ThenInclude(c=>c.MarketingArea)
                            .Include(o => o.OrderItems)
                            .ThenInclude(p => p.ProductSparepart)
                            .ToListAsync();
        }

        public async Task<List<string>> GetBtoBOrderIds()
        {
            return await _context.Orders
                            .Where(o => o.OrderType == OrderType.BtoB)
                            .Select(s => s.Id).ToListAsync();   
        }

        public async Task<Order> GetById(string id)
        {
            return await _context.Orders
                            .Include(c => c.Customer)
                            .Include(c => c.Store)
                            .ThenInclude(c => c.MarketingArea)
                            .Include(o => o.OrderItems)
                            .ThenInclude(p => p.ProductSparepart)
                            .FirstOrDefaultAsync(s=>s.Id == id);
        }

        public async Task<IEnumerable<Order>> GetSalesBtoBAll()
        {
            return await _context.Orders
                            .Include(c => c.Customer)
                            .Include(c => c.Store)
                            .ThenInclude(c => c.MarketingArea)
                            .Include(o => o.OrderItems)
                            .ThenInclude(p => p.ProductSparepart)
                            .Where(s=>s.OrderType == OrderType.BtoB)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetSalesRetailAll()
        {
            return await _context.Orders
                            .Include(c => c.Customer)
                            .Include(c => c.Store)
                            .ThenInclude(c => c.MarketingArea)
                            .Include(o=>o.OrderItems)
                            .ThenInclude(p=>p.ProductSparepart)
                            .Where(s => s.Customer.CustomerType == OrderType.Retail)
                            .ToListAsync();
        }
    }
}
