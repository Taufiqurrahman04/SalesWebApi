using MediatR;

namespace SalesOrderWebApi.Models.MediatRRequestModels
{
    public class ValidateBTwoBQuantity : IRequest<bool>
    {
        public Dictionary<string, int> Quantities { get; set; }
    }
}
