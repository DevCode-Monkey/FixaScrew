using System.Text.Json;
using System.Text.Json.Serialization;
using FixaScrew.DataSourceAgg.Common.Extensions;
using FixaScrew.DataSourceAgg.Common.Models;
using Microsoft.Extensions.Options;

namespace FixaScrew.DataSourceAgg.Services.JsonFileStore;
public class JsonService : Data<JsonResponse>, IJsonService
{
    private readonly DataLocationOptions _json;

    public JsonService(IOptionsSnapshot<DataLocationOptions> options) 
        => _json = options.Get(DataLocationOptions.Json);

    public async Task<List<DataResponse>> GetData() 
        => (from json in await Pull() select json.MapToDataResponse()).ToList();

    public override async Task<List<JsonResponse>> Pull()
    {
        var file = Path.Combine(_json.BaseDirectory, _json.Location);

        await using var stream = File.OpenRead(Path.GetFullPath(file));
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            }
        };
        
        return new List<JsonResponse>
        {
            await JsonSerializer.DeserializeAsync<JsonResponse>(stream, options) ?? new JsonResponse()
        };
    }
}