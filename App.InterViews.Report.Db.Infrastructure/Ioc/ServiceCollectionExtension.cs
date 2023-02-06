using App.InterViews.Report.Db.Infrastructure.Implements;
using App.InterViews.Report.Library.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InterViews.Report.Db.Infrastructure.Ioc
{
    public static class ServiceCollectionExtension
    {
        public static void InitializeInfrastructure(this IServiceCollection services) 
        {
            services.AddTransient(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
        }
    }
}
