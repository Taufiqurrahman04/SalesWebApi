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
    public class StoreController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StoreController> _logger;

        public StoreController(IMediator mediator,
            ILogger<StoreController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ListResponseViewModel<store>> Get()
        {
            _logger.LogInformation("Fetch all data of Account");

            var datas = await _mediator.Send(new GetStores());

            var result = new ListResponseViewModel<store>();

            if (datas == null)
            {
                _logger.LogInformation("No data of Accounts");

                result.StatusCode = StatusCodes.Status204NoContent;
                result.Message = "Data not found";
                result.Datas = new List<store>();

                return result;
            }

            result.StatusCode = StatusCodes.Status200OK;
            result.Message = "Success";
            result.Datas = datas;

            return result;
        }
    }
}
