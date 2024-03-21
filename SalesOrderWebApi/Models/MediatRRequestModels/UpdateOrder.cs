using MediatR;
using SalesOrderWebApi.Models.DataViewModels;

namespace SalesOrderWebApi.Models.MediatRRequestModels
{
    public class UpdateOrder : order, IRequest<order>
    {
    }
}
