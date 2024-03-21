using MediatR;
using SalesOrderWebApi.Models.DataViewModels;

namespace SalesOrderWebApi.Models.MediatRRequestModels
{
    public class UpdateOrderItem : order_item, IRequest<order_item>
    {
    }
}
