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
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(IMediator mediator, 
            ILogger<CustomerController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ListResponseViewModel<customer>> Get()
        {
            _logger.LogInformation("Fetch all data of Account");

            var datas = await _mediator.Send(new GetCustomers());

            var result = new ListResponseViewModel<customer>();

            if (datas == null)
            {
                _logger.LogInformation("No data of Accounts");

                result.StatusCode = StatusCodes.Status204NoContent;
                result.Message = "Data not found";
                result.Datas = new List<customer>();

                return result;
            }

            result.StatusCode = StatusCodes.Status200OK;
            result.Message = "Success";
            result.Datas = datas;

            return result;
        }
    }
}
