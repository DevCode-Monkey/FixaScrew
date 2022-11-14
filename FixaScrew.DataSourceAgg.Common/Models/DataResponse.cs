using FixaScrew.DataSourceAgg.Common.Enums;

namespace FixaScrew.DataSourceAgg.Common.Models;

public class DataResponse
{
    public BrandName Name { get; set; }
    public ProductType Item { get; set; }
    public decimal Cost { get; set; }
    public int TotalItems { get; set; }
}