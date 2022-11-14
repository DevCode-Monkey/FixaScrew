using System.Text.Json.Serialization;
using FixaScrew.DataSourceAgg.Common.Enums;

namespace FixaScrew.DataSourceAgg.Common.Models;

public class JsonResponse
{
    [JsonPropertyName("brand")]
    public BrandName Brand { get; set; }
    [JsonPropertyName("product")]
    public ProductType Product { get; set; }
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
    [JsonPropertyName("stockLevel")]
    public int StockLevel { get; set; }
}