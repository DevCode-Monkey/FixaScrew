using FixaScrew.DataSourceAgg.Api.Extensions;
using FixaScrew.DataSourceAgg.Common.Models;
using FixaScrew.DataSourceAgg.Services;
using FixaScrew.DataSourceAgg.Services.CsvFileStore;
using FixaScrew.DataSourceAgg.Services.JsonFileStore;
using FixaScrew.DataSourceAgg.Services.XmlFileStore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContexts();
builder.Services.AddFileOptions(builder);
builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();