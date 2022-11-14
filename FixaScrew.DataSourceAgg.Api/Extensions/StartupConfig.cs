using System.IO.Compression;
using FixaScrew.DataSourceAgg.Common.Contexts;
using FixaScrew.DataSourceAgg.Common.Models;
using FixaScrew.DataSourceAgg.Services;
using FixaScrew.DataSourceAgg.Services.CsvFileStore;
using FixaScrew.DataSourceAgg.Services.DatabaseFileStore;
using FixaScrew.DataSourceAgg.Services.JsonFileStore;
using FixaScrew.DataSourceAgg.Services.XmlFileStore;
using Microsoft.AspNetCore.ResponseCompression;

namespace FixaScrew.DataSourceAgg.Api.Extensions;

public static class StartupConfig
{
    public static void AddCompression(this IServiceCollection services)
    {
        services.Configure<GzipCompressionProviderOptions>(options =>
        {
            options.Level = CompressionLevel.SmallestSize;
        });
        services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<GzipCompressionProvider>();
        });
    }
    
    public static void AddFileOptions(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.Configure<DataLocationOptions>(DataLocationOptions.Xml,
            builder.Configuration.GetSection("FileTypes:Xml"));
        
        services.Configure<DataLocationOptions>(DataLocationOptions.Csv,
            builder.Configuration.GetSection("FileTypes:Csv"));

        services.Configure<DataLocationOptions>(DataLocationOptions.Json,
            builder.Configuration.GetSection("FileTypes:Json"));
    }
    
    public static void AddDbContexts(this IServiceCollection services) 
        => services.AddDbContext<ProductContext>();

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IJsonService, JsonService>();
        services.AddScoped<ICsvService, CsvService>();
        services.AddScoped<IXmlService, XmlService>();
        services.AddScoped<IDatabaseService, DatabaseService>();
        services.AddScoped<IDataStoreService, DataStoreService>();
    }
}