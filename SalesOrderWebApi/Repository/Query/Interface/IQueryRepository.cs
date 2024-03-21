namespace SalesOrderWebApi.Repository.Query.Interface
{
    public interface IQueryRepository<T> where T : class
    {
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
