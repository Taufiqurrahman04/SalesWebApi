using MediatR;
using SalesOrderWebApi.Models.DataModifyViewModels;
using SalesOrderWebApi.Models.DataViewModels;

namespace SalesOrderWebApi.Models.MediatRRequestModels
{
    public class CreateOrderItem : IRequest<IEnumerable<order_item>>
    {
        public List<order_item> items { get; set; }
    }
}
