using FixaScrew.DataSourceAgg.Common.Enums;

namespace FixaScrew.DataSourceAgg.Common.Entities;
public class SQLDataStore
{
    public int Id { get; set; }
    public BrandName Name { get; set; }
    public ProductType Product { get; set; }
    public decimal Amount { get; set; }
    public int StockAmount { get; set; }
}