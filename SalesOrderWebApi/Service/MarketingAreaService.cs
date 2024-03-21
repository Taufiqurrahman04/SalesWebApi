using AutoMapper;
using MediatR;
using Microsoft.Identity.Client;
using SalesOrderWebApi.Entity;
using SalesOrderWebApi.Models.DataViewModels;
using SalesOrderWebApi.Models.MediatRRequestModels;
using SalesOrderWebApi.Repository.Command.Interface;
using SalesOrderWebApi.Repository.Query.Interface;

namespace SalesOrderWebApi.Service
{
    public class MarketingAreaService : BaseServices<MarketingArea>,
        IRequestHandler<GetMarketingAreas, IEnumerable<marketing_area>>
    {
        private readonly IMapper _mapper;
        public MarketingAreaService(ICommandRepository<MarketingArea> commandRepository, 
            IQueryRepository<MarketingArea> queryRepository,
            IMapper mapper) 
            : base(commandRepository, queryRepository)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<marketing_area>> Handle(GetMarketingAreas request, CancellationToken cancellationToken)
        {
            var datas = await _queryRepository.GetAllAsync();

            if (!datas.Any())
                return null;

            var result = datas.Select(s=>_mapper.Map<marketing_area>(s));

            return result;
        }
    }
}
