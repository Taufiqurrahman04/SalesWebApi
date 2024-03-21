using SalesOrderWebApi.Repository.Command.Interface;
using SalesOrderWebApi.Repository.Query.Interface;

namespace SalesOrderWebApi.Service
{
    public class BaseServices<T> where T : class
    {
        protected readonly ICommandRepository<T> _commandRepository;
        protected readonly IQueryRepository<T> _queryRepository;

        public BaseServices(ICommandRepository<T> commandRepository, IQueryRepository<T> queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }
    }
}
