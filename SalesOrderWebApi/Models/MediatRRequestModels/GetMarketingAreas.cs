using MediatR;
using SalesOrderWebApi.Models.DataViewModels;

namespace SalesOrderWebApi.Models.MediatRRequestModels
{
    public class GetMarketingAreas : IRequest<IEnumerable<marketing_area>>
    {

    }
}
