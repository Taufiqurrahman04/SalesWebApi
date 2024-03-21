using AutoMapper;
using MediatR;
using SalesOrderWebApi.Entity;
using SalesOrderWebApi.Models.DataViewModels;
using SalesOrderWebApi.Models.MediatRRequestModels;
using SalesOrderWebApi.Repository.Command.Interface;
using SalesOrderWebApi.Repository.Query.Interface;

namespace SalesOrderWebApi.Service
{
    public class StoreService : BaseServices<Store>,
        IRequestHandler<GetStores,IEnumerable<store>>
    {
        private readonly IMapper _mapper;

        public StoreService(ICommandRepository<Store> commandRepository, 
            IQueryRepository<Store> queryRepository,
            IMapper mapper) 
            : base(commandRepository, queryRepository)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<store>> Handle(GetStores request, CancellationToken cancellationToken)
        {
            var datas = await _queryRepository.GetAllAsync();

            if (!datas.Any())
                return null;

            var result = datas.Select(s => _mapper.Map<store>(s));

            return result;
        }
    }
}
