using MediatR;
using SalesOrderWebApi.Models.DataViewModels;

namespace SalesOrderWebApi.Models.MediatRRequestModels
{
    public class GetOrderItems :IRequest<IEnumerable<order_item>>
    {
    }
}
