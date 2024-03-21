using MediatR;
using SalesOrderWebApi.Models.DataViewModels;

namespace SalesOrderWebApi.Models.MediatRRequestModels
{
    public class GetSalesB2BOrders : IRequest<IEnumerable<order>>
    {
    }
}
