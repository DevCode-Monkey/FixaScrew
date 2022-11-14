using FixaScrew.DataSourceAgg.Common.Enums;

namespace FixaScrew.DataSourceAgg.Common.Models;
public class Product
{
    public ProductType Name { get; set; }
    public List<Brand> Brand { get; init; } = new();
}