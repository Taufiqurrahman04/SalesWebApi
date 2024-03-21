using MediatR;
using SalesOrderWebApi.Models.DataViewModels;

namespace SalesOrderWebApi.Models.MediatRRequestModels
{
    public class GetCustomers : IRequest<IEnumerable<customer>>
    {

    }
}
