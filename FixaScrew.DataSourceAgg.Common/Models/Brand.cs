using FixaScrew.DataSourceAgg.Common.Enums;

namespace FixaScrew.DataSourceAgg.Common.Models;

public class Brand
{
    public BrandName Name { get; set; }
    public decimal Cost { get; set; }
    public int Stock { get; set; }
}