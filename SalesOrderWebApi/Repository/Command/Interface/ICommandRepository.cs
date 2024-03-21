using SalesOrderWebApi.Entity;

namespace SalesOrderWebApi.Repository.Command.Interface
{
    public interface ICommandRepository<T> where T : class
    {
        Task<bool> InsertAsync(T data);
        Task<bool> InsertRangeAsync(IEnumerable<T> datas);
        Task<bool> UpdateAsync(T data);
        Task<bool> DeleteAsync(string id);
    }
}
