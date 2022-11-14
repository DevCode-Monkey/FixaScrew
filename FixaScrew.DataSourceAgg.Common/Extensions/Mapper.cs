using System.Collections.Generic;
using FixaScrew.DataSourceAgg.Common.Enums;
using FixaScrew.DataSourceAgg.Common.Models;

namespace FixaScrew.DataSourceAgg.Common.Extensions;

public static class Mapper
{
    public static DataResponse MapToDataResponse(this CsvResponse input) =>
        new()
        {
            Name = input.Name,
            Item = input.Item,
            Cost = input.Cost,
            TotalItems = input.TotalItems
        };
    
    public static DataResponse MapToDataResponse(this JsonResponse input) =>
        new()
        {
            Name = input.Brand,
            Item = input.Product,
            Cost = input.Price,
            TotalItems = input.StockLevel
        };
    
    public static DataResponse MapToDataResponse(this XmlResponse input) =>
        new()
        {
            Name = input.NameOfBrand,
            Item = input.Items,
            Cost = input.Pricing,
            TotalItems = input.Inventory
        };

    public static Brand MapToBrand(this DataResponse input) =>
        new()
        {
            Name = input.Name,
            Cost = input.Cost,
            Stock = input.TotalItems
        };

    public static List<ProductsResponse> MapToListOfProductResponse(this List<Product> input) =>
        new()
        {
            new ProductsResponse
            {
                Products = input
            }
        };
}