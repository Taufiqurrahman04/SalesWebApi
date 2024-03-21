using Microsoft.EntityFrameworkCore;
using SalesOrderWebApi.Context;
using SalesOrderWebApi.Repository.Query.Interface;

namespace SalesOrderWebApi.Repository.Query.Service
{
    public class QueryRepository<T> : IQueryRepository<T> where T : class
    {
        private readonly QueryDbContext _context;

        public QueryRepository(QueryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
