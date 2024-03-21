using MediatR;
using SalesOrderWebApi.Models.DataViewModels;

namespace SalesOrderWebApi.Models.MediatRRequestModels
{
    public class GetStores : IRequest<IEnumerable<store>>
    {
    }
}
