using Microsoft.EntityFrameworkCore;
using SalesOrderWebApi.Context;

namespace SalesOrderWebApi.Repository.Command.Interface
{
    public class CommandRepository<T> : ICommandRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public CommandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            bool result = false;

            var entity = await GetByIdAsync(id);

            if (entity == null)
                return result;

            _context.Set<T>().Remove(entity);
            result = await _context.SaveChangesAsync() >-1;
            
            return result;
        }

        public async Task<bool> InsertAsync(T data)
        {
            await _context.Set<T>().AddAsync(data);
            return await _context.SaveChangesAsync() > -1;
        }

        public async Task<bool> UpdateAsync(T data)
        {
            _context.Entry(data).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > -1;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> InsertRangeAsync(IEnumerable<T> datas)
        {
            await _context.Set<T>().AddRangeAsync(datas);
            return await _context.SaveChangesAsync() > -1;
        }
    }
}
