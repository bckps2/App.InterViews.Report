using App.InterViews.Report.CrossCutting.CommonDto;
using App.InterViews.Report.Db.Infrastructure.Context;
using App.InterViews.Report.Db.Infrastructure.Ioc;
using App.InterViews.Report.Http;
using App.InterViews.Report.Models;
using App.InterViews.Report.Models.Interview;
using App.InterViews.Report.Service.Ioc;
using App.InterViews.Report.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace App.InterViews.Report.StartApp;

public static class ConfigurationApp
{
    public static ConfigurationManager? ConfigurationManager;

    public static void StartConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddHttpContextAccessor();
        services.AddScoped<IAutoMapperHttp, AutoMapperHttp>();
        services.InitializeInfrastructure();
        services.InitializeServices();
        ConfigureToken(services);
        ConfigureOptions(services);
        ConfgiurationDb(services);
        ConfigurationCors(services);
        ConfigureSwagger(services);
        InitializeValidators(services);
    }

    private static void ConfigureOptions(IServiceCollection services)
    {
        var appSettingsSection = ConfigurationManager?.GetSection("AppSettings");
        var tokenConfigurationValues = ConfigurationManager?.GetSection("Jwt");
        services.Configure<AppSettings>(appSettingsSection);
        services.Configure<TokenConfiguration>(tokenConfigurationValues);
    }

    public static void InitializeValidators(IServiceCollection services)
    {
        services.AddTransient<IValidator<CompanyModel>, CompanyValidator>();
        services.AddTransient<IValidator<InterviewModel>, InterViewValidator>();
        services.AddTransient<IValidator<ProcessModel>, ProccesValidator>();
    }

    public static Logger ConfigurationSerilog()
    {
        var appSettings = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var logDB = ConfigurationManager?.GetSection("ConnectionStrings:DbInterviews").Value;
        var sinkOpts = new MSSqlServerSinkOptions { TableName = "LogRecords", AutoCreateSqlTable = true };

        var columnOptions = new ColumnOptions
        {
            AdditionalColumns = new Collection<SqlColumn>
                {
                    new SqlColumn("IdType", SqlDbType.NVarChar),
                    new SqlColumn("CustomType", SqlDbType.NVarChar)
                }
        };
        return new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Error)
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
            options.UseSqlServer(ConfigurationManager.GetConnectionString("DbInterviews"),
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

    private static void ConfigureToken(IServiceCollection services)
    {
        if (ConfigurationManager != null)
        {
            services
           .AddHttpContextAccessor()
           .AddAuthorization()
           .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = ConfigurationManager["Jwt:Issuer"],
                   ValidAudience = ConfigurationManager["Jwt:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager["Jwt:Key"]))
               };
           });
        }
    }

    private static void ConfigureSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "Bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
        });
    }
}
