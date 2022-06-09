using Serilog;
using System.Data;
using Serilog.Sinks.MSSqlServer;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Db.Infrastructure.Context;
using App.InterViews.Report.Db.Infrastructure.Implements;
using App.InterViews.Report.Impl.Service.ServiceInterviewReport;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IInterViewReportService, InterViewReportService>();
builder.Services.AddScoped<IRepositoryInterView, RepositoryInterView>();
builder.Services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

var appSettings = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var logDB = builder.Configuration.GetSection("ConnectionStrings:DbInterviews").Value;
var sinkOpts = new MSSqlServerSinkOptions { TableName = "LogRecords", AutoCreateSqlTable = true };

var columnOptions = new ColumnOptions
{
    AdditionalColumns = new Collection<SqlColumn>
    {
        new SqlColumn("IdType", SqlDbType.Int),
        new SqlColumn("CustomType", SqlDbType.NVarChar)
    }
};

var logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
    .WriteTo.MSSqlServer(
        connectionString: logDB,
        sinkOptions: sinkOpts,
        columnOptions: columnOptions,
        appConfiguration: appSettings
    ).CreateLogger();

builder.Logging.AddSerilog(logger);

Log.Logger = logger;

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
           builder =>
           {
               builder.WithOrigins("*")
               .WithHeaders("*")
               .WithMethods("*");
           });
});

builder.Services.AddHealthChecks();

builder.Services.AddDbContext<DbDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbInterviews"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks("/health");

app.UseCors("AllowSpecificOrigin");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
