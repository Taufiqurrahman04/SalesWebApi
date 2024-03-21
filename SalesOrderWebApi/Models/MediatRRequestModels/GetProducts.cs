using MediatR;
using SalesOrderWebApi.Models.DataViewModels;

namespace SalesOrderWebApi.Models.MediatRRequestModels
{
    public class GetProducts : IRequest<IEnumerable<product_sparepart>>
    {
    }
}
