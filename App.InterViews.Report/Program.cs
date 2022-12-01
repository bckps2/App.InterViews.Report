using Serilog;
using System.Data;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Db.Infrastructure.Context;
using App.InterViews.Report.Db.Infrastructure.Implements;
using App.InterViews.Report.Impl.Service.ServiceInterviewReport;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using App.InterViews.Report.StartApp;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

ConfigurationApp.configurationManager = builder.Configuration;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.StartConfiguration();
Log.Logger = ConfigurationApp.ConfigurationSerilog();
builder.Logging.AddSerilog(Log.Logger);

builder.Services.AddHealthChecks();


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
