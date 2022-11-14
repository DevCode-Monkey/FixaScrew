using FixaScrew.DataSourceAgg.Common.Enums;

namespace FixaScrew.DataSourceAgg.Common.Models;

public class XmlResponse
{
    public BrandName NameOfBrand { get; init; }
    public ProductType Items { get; init; }
    public decimal Pricing { get; init; }
    public int Inventory { get; init; }
}