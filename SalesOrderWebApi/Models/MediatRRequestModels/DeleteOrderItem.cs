using MediatR;
using SalesOrderWebApi.Models.DataViewModels;

namespace SalesOrderWebApi.Models.MediatRRequestModels
{
    public class DeleteOrderItem : IRequest<order_item>
    {
        public string Id { get; set; }
    }
}
