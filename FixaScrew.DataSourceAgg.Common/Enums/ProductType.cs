using System.Text.Json.Serialization;

namespace FixaScrew.DataSourceAgg.Common.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProductType
{
    Drill = 1,
    Screwdriver,
    Sander,
    Screws,
    Nails,
    Hammer
}