using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using App.InterViews.Report.Impl.Service.ServiceInterviewReport;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InterViews.Report.Impl.Service.Ioc
{
    public static class ServiceCollectionExtension
    {
        public static void InitializeServices(this IServiceCollection services) 
        {
            services.AddTransient(typeof(ICompanyReportservice<,>), typeof(CompanyReportService<,>));
            services.AddTransient(typeof(IInterViewReportService<,>), typeof(InterViewReportService<,>));
            services.AddTransient(typeof(IProcessReportService<>), typeof(ProcessReportService<>));
        }
    }
}
