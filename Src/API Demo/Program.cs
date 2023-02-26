using API_Demo.Interfaces;
using API_Demo.Services;
using ApiExceptionPipelineV2._0.Entities;
using ApiExceptionPipelineV2._0.Extensions;
using ApiExceptionPipelineV2._0.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IServiceCollection services = builder.Services;
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddSingleton<IExceptionService, ExceptionService>();

var app = builder.Build();
IConfiguration configuration = app.Configuration;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//get exception options from appsettings.json
ExceptionOptions options = new();
configuration.GetSection("ExceptionOptions")
    .Bind(options);
//use the exception options to pass into the exception pipeline
app.UseCustomExceptionPipeline(options);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
