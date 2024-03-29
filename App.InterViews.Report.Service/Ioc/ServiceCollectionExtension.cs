﻿using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using App.InterViews.Report.Service.ServiceInterViewReport.Implements;
using Microsoft.Extensions.DependencyInjection;

namespace App.InterViews.Report.Service.Ioc
{
    public static class ServiceCollectionExtension
    {
        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICompanyReportService), typeof(CompanyReportService));
            services.AddScoped(typeof(IInterViewReportService), typeof(InterViewReportService));
            services.AddScoped(typeof(IProcessReportService), typeof(ProcessReportService));
            services.AddScoped(typeof(IUserReportService), typeof(UserReportService));
            services.AddScoped(typeof(IRoleReportService), typeof(RoleReportService));
            services.AddScoped(typeof(IInterviewerService), typeof(InterviewerService));
            services.AddScoped(typeof(IUserAccountService), typeof(UserAccountService));
        }
    }
}
