using FixaScrew.DataSourceAgg.Common.Enums;

namespace FixaScrew.DataSourceAgg.Common.Models;

public class DataResponse
{
    public BrandName Name { get; init; }
    public ProductType Item { get; init; }
    public decimal Cost { get; init; }
    public int TotalItems { get; init; }
}