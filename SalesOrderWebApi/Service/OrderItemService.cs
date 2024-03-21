using AutoMapper;
using MediatR;
using SalesOrderWebApi.Entity;
using SalesOrderWebApi.Models.DataViewModels;
using SalesOrderWebApi.Models.MediatRRequestModels;
using SalesOrderWebApi.Repository.Command.Interface;
using SalesOrderWebApi.Repository.Query.Interface;

namespace SalesOrderWebApi.Service
{
    public class OrderItemService : BaseServices<OrderItem>,
        IRequestHandler<GetOrderItems, IEnumerable<order_item>>,
        IRequestHandler<GetOrderItemById, order_item>,
        IRequestHandler<CreateOrderItem, IEnumerable<order_item>>,
        IRequestHandler<UpdateOrderItem, order_item>,
        IRequestHandler<DeleteOrderItem, order_item>

    {
        private readonly IMapper _mapper;
        public OrderItemService(ICommandRepository<OrderItem> commandRepository, 
            IQueryRepository<OrderItem> queryRepository,
            IMapper mapper) 
            : base(commandRepository, queryRepository)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<order_item>> Handle(GetOrderItems request, CancellationToken cancellationToken)
        {
            var datas = await _queryRepository.GetAllAsync();

            if (!datas.Any())
                return null;

            var result = datas.Select(s => _mapper.Map<order_item>(s));

            return result;
        }

        public async Task<order_item> Handle(GetOrderItemById request, CancellationToken cancellationToken)
        {
            var data = await _queryRepository.GetByIdAsync(request.Id);

            if (data == null)
                return null;

            var result = _mapper.Map<order_item>(data);

            return result;
        }

        public async Task<IEnumerable<order_item>> Handle(CreateOrderItem request, CancellationToken cancellationToken)
        {
            var datas = request.items.Select(d=> 
            {
                var item = _mapper.Map<OrderItem>(d);
                item.Id = Guid.NewGuid().ToString();
                return item;
            });

            var isSuccess = await _commandRepository.InsertRangeAsync(datas);

            if (!isSuccess)
                return null;

            var result = datas.Select(it => _mapper.Map<order_item>(it));

            return result;
        }

        public async Task<order_item> Handle(UpdateOrderItem request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<OrderItem>(request);

            var isSuccess = await _commandRepository.UpdateAsync(data);

            if (!isSuccess)
                return null;

            return request;
        }

        public async Task<order_item> Handle(DeleteOrderItem request, CancellationToken cancellationToken)
        {
            var isDeleted = await _commandRepository.DeleteAsync(request.Id);

            if (!isDeleted)
                return null;

            var data = _mapper.Map<order_item>( await _queryRepository.GetByIdAsync(request.Id));

            return data;
        }

        
    }
}
