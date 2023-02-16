using API_Demo.Exceptions;
using ApiExceptionPipelineV2._0.Entities;
using ApiExceptionPipelineV2._0.Extensions;
using ApiExceptionPipelineV2._0.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IServiceCollection services = builder.Services;
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddSingleton<IException, DefaultException>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionPipeline(
    exceptionDecoder: ExceptionDecoder.CustomExceptions,
    exceptionMaps: ExceptionDecoder.CustomExceptionMaps
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
