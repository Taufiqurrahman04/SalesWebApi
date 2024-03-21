using MediatR;
using SalesOrderWebApi.Models.DataViewModels;

namespace SalesOrderWebApi.Models.MediatRRequestModels
{
    public class GetOrderById : IRequest<order>
    {
        public string Id { get; set; }
    }
}
