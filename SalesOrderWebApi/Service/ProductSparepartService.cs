using AutoMapper;
using MediatR;
using SalesOrderWebApi.Entity;
using SalesOrderWebApi.Models.DataViewModels;
using SalesOrderWebApi.Models.MediatRRequestModels;
using SalesOrderWebApi.Repository.Command.Interface;
using SalesOrderWebApi.Repository.Query.Interface;

namespace SalesOrderWebApi.Service
{
    public class ProductSparepartService : BaseServices<ProductSparepart>,
        IRequestHandler<GetProducts, IEnumerable<product_sparepart>>
    {
        private readonly IMapper _mapper;

        public ProductSparepartService(ICommandRepository<ProductSparepart> commandRepository, 
            IQueryRepository<ProductSparepart> queryRepository,
            IMapper mapper) 
            : base(commandRepository, queryRepository)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<product_sparepart>> Handle(GetProducts request, CancellationToken cancellationToken)
        {
            var datas = await _queryRepository.GetAllAsync();

            if (!datas.Any())
                return null;

            var result = datas.Select(s => _mapper.Map<product_sparepart>(s));

            return result;
        }
    }
}
