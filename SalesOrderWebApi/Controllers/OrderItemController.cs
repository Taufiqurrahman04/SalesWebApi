using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    public class OrderItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderItemController> _logger;
        private readonly IMapper _mapper;

        public OrderItemController(IMediator mediator,
            ILogger<OrderItemController> logger,
            IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ListResponseViewModel<order_item>> Get()
        {
            _logger.LogInformation("Fetch all data of Account");

            var datas = await _mediator.Send(new GetOrderItems());

            var result = new ListResponseViewModel<order_item>();

            if (datas == null)
            {
                _logger.LogInformation("No data of Accounts");

                result.StatusCode = StatusCodes.Status204NoContent;
                result.Message = "Data not found";
                result.Datas = new List<order_item>();

                return result;
            }

            result.StatusCode = StatusCodes.Status200OK;
            result.Message = "Success";
            result.Datas = datas;

            return result;
        }

        [HttpPost]
        public async Task<ListResponseViewModel<order_item>> Post([FromBody] List<base_order_item> datas)
        {
            var result = new ListResponseViewModel<order_item>();

            if(datas == null || datas.Count == 0)
            {
                result.StatusCode = StatusCodes.Status400BadRequest;
                result.Message = "The parameter cant be null or empty";

                return result;
            }

            var getBtoBOrderQuantity = datas.GroupBy(s => s.order_id).ToDictionary(s => s.Key, s => s.Sum(q => q.quantity));

            var isValidBtoBe = await _mediator.Send(new ValidateBTwoBQuantity { Quantities = getBtoBOrderQuantity });

            if (!isValidBtoBe)
            {
                result.StatusCode = StatusCodes.Status400BadRequest;
                result.Message = "Quantity for Sales BtoB must bigger than 100";

                return result;
            }

            _logger.LogInformation("Start to insert the data");

            var response = await _mediator.Send(new CreateOrderItem
            {
                items=datas.Select(s=>_mapper.Map<order_item>(s)).ToList()
            });

            if (!response.Any())
            {
                _logger.LogInformation("No data created");

                result.StatusCode = StatusCodes.Status304NotModified;
                result.Message = "No data created";
                result.Datas = null;

                return result;
            }

            result.StatusCode = StatusCodes.Status200OK;
            result.Message = "New Record Created.";
            result.Datas = response;

            return result;
        }

        [HttpPut("{id}")]
        public async Task<SingleResponseViewModel<order_item>> Put(string id, [FromBody] base_order_item data)
        {
            var result = new SingleResponseViewModel<order_item>();

            if (string.IsNullOrEmpty(id))
            {
                result.StatusCode = StatusCodes.Status400BadRequest;
                result.Message = "The parameter cant be null or empty";

                return result;
            }

            _logger.LogInformation("Start to update the data");

            var request = _mapper.Map<UpdateOrderItem>(data);
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
        public async Task<SingleResponseViewModel<order_item>> Delete(string id)
        {
            var result = new SingleResponseViewModel<order_item>();

            if (string.IsNullOrEmpty(id))
            {
                result.StatusCode = StatusCodes.Status400BadRequest;
                result.Message = "The parameter cant be null or empty";

                return result;
            }

            _logger.LogInformation("Start to delete the data");

            var response = await _mediator.Send(new DeleteOrderItem
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
