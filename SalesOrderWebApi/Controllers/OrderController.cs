using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesOrderWebApi.Models.DataModifyViewModels;
using SalesOrderWebApi.Models.DataViewModels;
using SalesOrderWebApi.Models.MediatRRequestModels;
using ViewModel;

namespace SalesOrderWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;

        public OrderController(IMediator mediator,
            ILogger<OrderController> logger,
            IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ListResponseViewModel<order>> Get()
        {
            _logger.LogInformation("Fetch all data of Account");

            var datas = await _mediator.Send(new GetOrders());

            var result = new ListResponseViewModel<order>();

            if (datas == null)
            {
                _logger.LogInformation("No data of Accounts");

                result.StatusCode = StatusCodes.Status204NoContent;
                result.Message = "Data not found";
                result.Datas = new List<order>();

                return result;
            }

            result.StatusCode = StatusCodes.Status200OK;
            result.Message = "Success";
            result.Datas = datas;

            return result;
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = UserRoleName.Admin + "," + UserRoleName.User)]
        public async Task<SingleResponseViewModel<order>> Get(string id)
        {
            var result = new SingleResponseViewModel<order>();

            if(string.IsNullOrEmpty(id))
            {
                result.StatusCode = StatusCodes.Status400BadRequest;
                result.Message = "The parameter cant be null or empty";

                return result;
            }

            _logger.LogInformation("Fetch particular Account for this id = " + id);

            var data = await _mediator.Send(new GetOrderById
            {
                Id = id,
            });

            if (data == null)
            {
                _logger.LogInformation("No data of Account for this id = " + id + " found.");

                result.StatusCode = StatusCodes.Status204NoContent;
                result.Message = "Data not found";
                result.Data = null;

                return result;
            }

            result.StatusCode = StatusCodes.Status200OK;
            result.Message = "Success";
            result.Data = data;

            return result;
        }

        [HttpGet("Sales/B2B")]
        public async Task<ListResponseViewModel<order>> GetSalesB2B()
        {
            _logger.LogInformation("Fetch all data of Account");

            var datas = await _mediator.Send(new GetSalesB2BOrders());

            var result = new ListResponseViewModel<order>();

            if (datas == null)
            {
                _logger.LogInformation("No data of Accounts");

                result.StatusCode = StatusCodes.Status204NoContent;
                result.Message = "Data not found";
                result.Datas = new List<order>();

                return result;
            }

            result.StatusCode = StatusCodes.Status200OK;
            result.Message = "Success";
            result.Datas = datas;

            return result;
        }

        [HttpGet("Sales/Retail")]
        public async Task<ListResponseViewModel<order>> GetSalesRetail()
        {
            _logger.LogInformation("Fetch all data of Account");

            var datas = await _mediator.Send(new GetSalesRetailOrders());

            var result = new ListResponseViewModel<order>();

            if (datas == null)
            {
                _logger.LogInformation("No data of Accounts");

                result.StatusCode = StatusCodes.Status204NoContent;
                result.Message = "Data not found";
                result.Datas = new List<order>();

                return result;
            }

            result.StatusCode = StatusCodes.Status200OK;
            result.Message = "Success";
            result.Datas = datas;

            return result;
        }

        [HttpPost]
        public async Task<SingleResponseViewModel<order>> Post([FromBody] base_order data)
        {
            var result = new SingleResponseViewModel<order>();

            _logger.LogInformation("Start to insert the data");

            var response = await _mediator.Send(_mapper.Map<CreateOrder>(data));

            if (response == null)
            {
                _logger.LogInformation("No data created");

                result.StatusCode = StatusCodes.Status304NotModified;
                result.Message = "No data created";
                result.Data = null;

                return result;
            }

            result.StatusCode = StatusCodes.Status200OK;
            result.Message = "New Record Created.";
            result.Data = response;

            return result;

        }

        [HttpPut("{id}")]
        public async Task<SingleResponseViewModel<order>> Put(string id, [FromBody] base_order data)
        {
            var result = new SingleResponseViewModel<order>();

            if (string.IsNullOrEmpty(id))
            {
                result.StatusCode = StatusCodes.Status400BadRequest;
                result.Message = "The parameter cant be null or empty";

                return result;
            }

            _logger.LogInformation("Start to update the data");

            var request = _mapper.Map<UpdateOrder>(data);
            request.id = id;

            var response = await _mediator.Send(request);

            if (response == null)
            {
                _logger.LogInformation("No data of updated");

                result.StatusCode = StatusCodes.Status304NotModified;
                result.Message = "No data updated";
                result.Data = null;

                return result;
            }

            result.StatusCode = StatusCodes.Status200OK;
            result.Message = "Data updated.";
            result.Data = response;

            return result;
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public async Task<SingleResponseViewModel<order>> Delete(string id)
        {
            var result = new SingleResponseViewModel<order>();

            if (string.IsNullOrEmpty(id))
            {
                result.StatusCode = StatusCodes.Status400BadRequest;
                result.Message = "The parameter cant be null or empty";

                return result;
            }

            _logger.LogInformation("Start to delete the data");

            var response = await _mediator.Send(new DeleteOrder
            {
                Id = id
            });

            if (response == null)
            {
                _logger.LogInformation("No data deleted");

                result.StatusCode = StatusCodes.Status304NotModified;
                result.Message = "No data deleted";
                result.Data = null;

                return result;
            }

            result.StatusCode = StatusCodes.Status200OK;
            result.Message = "This data removed from database.";
            result.Data = response;

            return result;
        }
    }
}
