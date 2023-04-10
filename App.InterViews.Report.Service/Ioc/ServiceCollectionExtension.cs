using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using App.InterViews.Report.Service.ServiceInterViewReport.Implements;
using Microsoft.Extensions.DependencyInjection;

namespace App.InterViews.Report.Service.Ioc
{
    public static class ServiceCollectionExtension
    {
        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddSingleton(typeof(ICompanyReportService<>), typeof(CompanyReportService<>));
            services.AddSingleton(typeof(IInterViewReportService<>), typeof(InterViewReportService<>));
            services.AddSingleton(typeof(IProcessReportService<>), typeof(ProcessReportService<>));
        }
    }
}
