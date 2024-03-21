using MediatR;
using SalesOrderWebApi.Models.DataViewModels;

namespace SalesOrderWebApi.Models.MediatRRequestModels
{
    public class GetSalesRetailOrders : IRequest<IEnumerable<order>>
    {
    }
}
