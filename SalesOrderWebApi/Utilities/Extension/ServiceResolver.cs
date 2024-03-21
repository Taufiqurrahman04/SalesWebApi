using SalesOrderWebApi.Repository.Command.Interface;
using SalesOrderWebApi.Repository.Query.Interface;
using SalesOrderWebApi.Repository.Query.Service;

namespace Utilities.Extension
{
    public static class ServiceResolver
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddScoped<IOrderExtend, OrderExtend>();
        }
    }
}
