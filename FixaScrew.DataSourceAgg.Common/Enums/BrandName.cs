using System.Text.Json.Serialization;

namespace FixaScrew.DataSourceAgg.Common.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BrandName
{
    BlackDecker = 1,
    DeWalt,
    Makita,
    Bosch
}