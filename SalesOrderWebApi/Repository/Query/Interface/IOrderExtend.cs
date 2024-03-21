using SalesOrderWebApi.Entity;

namespace SalesOrderWebApi.Repository.Query.Interface
{
    public interface IOrderExtend
    {
        Task<IEnumerable<Order>> GetAll();
        Task<IEnumerable<Order>> GetSalesBtoBAll();
        Task<IEnumerable<Order>> GetSalesRetailAll();
        Task<Order> GetById(string id);
        Task<List<string>> GetBtoBOrderIds();
    }
}
