using AutoMapper;
using MediatR;
using SalesOrderWebApi.Entity;
using SalesOrderWebApi.Models.DataViewModels;
using SalesOrderWebApi.Models.MediatRRequestModels;
using SalesOrderWebApi.Repository.Command.Interface;
using SalesOrderWebApi.Repository.Query.Interface;

namespace SalesOrderWebApi.Service
{
    public class OrderServices : BaseServices<Order>, 
        IRequestHandler<GetOrders, IEnumerable<order>>,
        IRequestHandler<GetSalesB2BOrders, IEnumerable<order>>,
        IRequestHandler<GetSalesRetailOrders, IEnumerable<order>>,
        IRequestHandler<GetOrderById, order>,
        IRequestHandler<CreateOrder, order>,
        IRequestHandler<UpdateOrder, order>,
        IRequestHandler<DeleteOrder, order>,
        IRequestHandler<ValidateBTwoBQuantity, bool>
    {
        private readonly IMapper _mapper;
        private readonly IOrderExtend _orderRepository;

        public OrderServices(ICommandRepository<Order> commandRepository, 
                             IQueryRepository<Order> queryRepository,
                             IMapper mapper,
                             IOrderExtend orderRepository) 
            : base(commandRepository, queryRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<order>> Handle(GetOrders request, CancellationToken cancellationToken)
        {
            var datas = await _orderRepository.GetAll();

            if (!datas.Any())
                return null;

            var result = datas.Select(d=> 
                            {
                                var data = _mapper.Map<order>(d);
                                data.customer = _mapper.Map<customer>(d.Customer);
                                data.store = _mapper.Map<store>(d.Store);
                                data.order_Items = d.OrderItems.Select(o =>
                                {
                                    var item = _mapper.Map<order_item>(o);
                                    item.product_sparepart = _mapper.Map<product_sparepart>(o.ProductSparepart);
                                    return item;
                                });
                                return data;
                            }).ToList();

            return result;
        }

        public async Task<IEnumerable<order>> Handle(GetSalesB2BOrders request, CancellationToken cancellationToken)
        {
            var datas = await _orderRepository.GetSalesBtoBAll();

            if (!datas.Any())
                return null;

            var result = datas.Select(d =>
            {
                var data = _mapper.Map<order>(d);
                data.customer = _mapper.Map<customer>(d.Customer);
                data.store = _mapper.Map<store>(d.Store);
                data.order_Items = d.OrderItems.Select(o =>
                {
                    var item = _mapper.Map<order_item>(o);
                    item.product_sparepart = _mapper.Map<product_sparepart>(o.ProductSparepart);
                    return item;
                });
                return data;
            }).ToList();

            return result;
        }

        public async Task<IEnumerable<order>> Handle(GetSalesRetailOrders request, CancellationToken cancellationToken)
        {
            var datas = await _orderRepository.GetSalesRetailAll();

            if (!datas.Any())
                return null;

            var result = datas.Select(d =>
            {
                var data = _mapper.Map<order>(d);
                data.customer = _mapper.Map<customer>(d.Customer);
                data.store = _mapper.Map<store>(d.Store);
                data.order_Items = d.OrderItems.Select(o =>
                {
                    var item = _mapper.Map<order_item>(o);
                    item.product_sparepart = _mapper.Map<product_sparepart>(o.ProductSparepart);
                    return item;
                });
                return data;
            }).ToList();

            return result;
        }

        public async Task<order> Handle(GetOrderById request, CancellationToken cancellationToken)
        {
            var data = await _orderRepository.GetById(request.Id);

            if (data == null)
                return null;

            var result = _mapper.Map<order>(data);
            result.customer = _mapper.Map<customer>(data.Customer);
            result.store = _mapper.Map<store>(data.Store);
            result.order_Items = data.OrderItems.Select(o =>
            {
                var item = _mapper.Map<order_item>(o);
                item.product_sparepart = _mapper.Map<product_sparepart>(o.ProductSparepart);
                return item;
            });

            return result;
        }

        public async Task<order> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Order>(request);
            data.Id = Guid.NewGuid().ToString();

            var isSuccess = await _commandRepository.InsertAsync(data);

            if (!isSuccess)
                return null;

            request.id = data.Id;

            return request;
        }

        public async Task<order> Handle(UpdateOrder request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Order>(request);

            var isSuccess = await _commandRepository.UpdateAsync(data);

            if (!isSuccess)
                return null;

            return request;
        }

        public async Task<order> Handle(DeleteOrder request, CancellationToken cancellationToken)
        {
           var isSuccess = await _commandRepository.DeleteAsync(request.Id);

            if (!isSuccess)
                return null;

            var data = _mapper.Map<order>(await _queryRepository.GetByIdAsync(request.Id));

            return data;
        }

        public async Task<bool> Handle(ValidateBTwoBQuantity request, CancellationToken cancellationToken)
        {
            if (!request.Quantities.Any())
                return true;

            var btobOrderIds = await _orderRepository.GetBtoBOrderIds();

            if (!btobOrderIds.Any())
                return true;

            if (request.Quantities.Any(s => btobOrderIds.Contains(s.Key) && s.Value <= 100))
                return false;

            return true;
        }
    }
}
