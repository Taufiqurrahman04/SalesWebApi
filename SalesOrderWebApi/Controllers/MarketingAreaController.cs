using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesOrderWebApi.Models.DataViewModels;
using SalesOrderWebApi.Models.MediatRRequestModels;
using ViewModel;

namespace SalesOrderWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketingAreaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MarketingAreaController> _logger;

        public MarketingAreaController(IMediator mediator,
            ILogger<MarketingAreaController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ListResponseViewModel<marketing_area>> Get()
        {
            _logger.LogInformation("Fetch all data of Account");

            var datas = await _mediator.Send(new GetMarketingAreas());

            var result = new ListResponseViewModel<marketing_area>();

            if (datas == null)
            {
                _logger.LogInformation("No data of Accounts");

                result.StatusCode = StatusCodes.Status204NoContent;
                result.Message = "Data not found";
                result.Datas = new List<marketing_area>();

                return result;
            }

            result.StatusCode = StatusCodes.Status200OK;
            result.Message = "Success";
            result.Datas = datas;

            return result;
        }
    }
}
