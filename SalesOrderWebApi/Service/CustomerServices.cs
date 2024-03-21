using AutoMapper;
using MediatR;
using SalesOrderWebApi.Entity;
using SalesOrderWebApi.Models.DataViewModels;
using SalesOrderWebApi.Models.MediatRRequestModels;
using SalesOrderWebApi.Repository.Command.Interface;
using SalesOrderWebApi.Repository.Query.Interface;

namespace SalesOrderWebApi.Service
{
    public class CustomerServices : BaseServices<Customer>, 
        IRequestHandler<GetCustomers,IEnumerable<customer>>
    {
        private readonly IMapper _mapper;
        public CustomerServices(ICommandRepository<Customer> commandRepository, 
            IQueryRepository<Customer> queryRepository,
            IMapper mapper) : 
            base(commandRepository, queryRepository)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<customer>> Handle(GetCustomers request, CancellationToken cancellationToken)
        {
            var datas = await _queryRepository.GetAllAsync();

            if (!datas.Any())
                return null;

            var result = datas.Select(d=>_mapper.Map<customer>(d));

            return result;
        }
    }
}
