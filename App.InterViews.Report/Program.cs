using App.InterViews.Report.StartApp;
using Serilog;
using System.Text.Json.Serialization;

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

app.UseSwagger();

app.UseSwaggerUI();

app.UseHealthChecks("/health");

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
