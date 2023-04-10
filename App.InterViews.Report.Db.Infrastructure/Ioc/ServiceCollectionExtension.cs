using Microsoft.Extensions.DependencyInjection;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Db.Infrastructure.Implements;

namespace App.InterViews.Report.Db.Infrastructure.Ioc
{
    public static class ServiceCollectionExtension
    {
        public static void InitializeInfrastructure(this IServiceCollection services) 
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        }
    }
}
