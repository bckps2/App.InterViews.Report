using Microsoft.Extensions.DependencyInjection;

namespace App.InterViews.Report.Service.Ioc
{
    public static class ServiceCollectionExtension
    {
        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(ICompanyReportservice<>), typeof(CompanyReportService<>));
            services.AddTransient(typeof(IInterViewReportService<>), typeof(InterViewReportService<>));
            services.AddTransient(typeof(IProcessReportService<>), typeof(ProcessReportService<>));
        }
    }
}
