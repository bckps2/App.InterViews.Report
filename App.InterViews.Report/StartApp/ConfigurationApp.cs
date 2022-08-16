using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using App.InterViews.Report.Db.Infrastructure.Context;
using App.InterViews.Report.Db.Infrastructure.Implements;
using App.InterViews.Report.Impl.Service.ServiceInterviewReport;
using App.InterViews.Report.Library.Contracts;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;

namespace App.InterViews.Report.StartApp
{
    public static class ConfigurationApp
    {
        public static ConfigurationManager configurationManager;

        public static void StartConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ICompanyReportservice, CompanyReportService>();
            services.AddScoped<IInterViewReportService, InterViewReportService>();
            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IProcessReportService, ProcessReportService>();

            ConfgiurationDb(services);
            ConfigurationCors(services);
        }

        public static Logger ConfigurationSerilog()
        {
            var appSettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var logDB = configurationManager.GetSection("ConnectionStrings:DbInterviews").Value;
            var sinkOpts = new MSSqlServerSinkOptions { TableName = "LogRecords", AutoCreateSqlTable = true };

            var columnOptions = new ColumnOptions
            {
                AdditionalColumns = new Collection<SqlColumn>
                {
                    new SqlColumn("IdType", SqlDbType.Int),
                    new SqlColumn("CustomType", SqlDbType.NVarChar)
                }
            };

            return new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
                .WriteTo.MSSqlServer(
                    connectionString: logDB,
                    sinkOptions: sinkOpts,
                    columnOptions: columnOptions,
                    appConfiguration: appSettings
                ).CreateLogger();

        }

        private static void ConfgiurationDb(IServiceCollection services) 
        {
            services.AddDbContext<DbDataContext>(options =>
            {
                options.UseSqlServer(configurationManager.GetConnectionString("DbInterviews"),
                    x => x.MigrationsAssembly("App.InterViews.Report.Migrations"));
            });
        }

        private static void ConfigurationCors(IServiceCollection services) 
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                       builder =>
                       {
                           builder.WithOrigins("*")
                           .WithHeaders("*")
                           .WithMethods("*");
                       });
            });
        } 
    }
}
