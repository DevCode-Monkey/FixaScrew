using System.Text.Json;
using System.Text.Json.Serialization;
using FixaScrew.DataSourceAgg.Api.Extensions;
using FixaScrew.DataSourceAgg.Common.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCompression();
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=> c.EnableAnnotations());

builder.Services.AddMemoryCache();
builder.Services.AddDbContexts();
builder.Services.AddFileOptions(builder);
builder.Services.AddServices();

var app = builder.Build();
app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<LoggingHandlerMiddleware>();

app.MapControllers();

app.Run();