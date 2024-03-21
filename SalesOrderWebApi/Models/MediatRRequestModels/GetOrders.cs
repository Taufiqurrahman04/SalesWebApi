using MediatR;
using SalesOrderWebApi.Models.DataViewModels;

namespace SalesOrderWebApi.Models.MediatRRequestModels
{
    public class GetOrders : IRequest<IEnumerable<order>>
    {
    }
}
