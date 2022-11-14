using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FixaScrew.DataSourceAgg.Common.Extensions;
using FixaScrew.DataSourceAgg.Common.Models;
using FixaScrew.DataSourceAgg.Services.CsvFileStore;
using FixaScrew.DataSourceAgg.Services.DatabaseFileStore;
using FixaScrew.DataSourceAgg.Services.JsonFileStore;
using FixaScrew.DataSourceAgg.Services.XmlFileStore;

namespace FixaScrew.DataSourceAgg.Services;

public class DataStoreService: IDataStoreService
{
    private readonly IJsonService _jsonService;
    private readonly ICsvService _csvService;
    private readonly IXmlService _xmlService;
    private readonly IDatabaseService _dataStoreService;

    public DataStoreService(
        IJsonService jsonService, 
        ICsvService csvService, 
        IXmlService xmlService,
        IDatabaseService dataStoreService
        )
    {
        _jsonService = jsonService;
        _csvService = csvService;
        _xmlService = xmlService;
        _dataStoreService = dataStoreService;
    }
    
    public async Task<List<ProductsResponse>> PollDataStores()
    {
        var results = new List<DataResponse>();

        results.AddRange(await _jsonService.GetData());
        results.AddRange(await _csvService.GetData());
        results.AddRange(await _xmlService.GetData());
        results.AddRange(await _dataStoreService.GetData());
        
        return GroupResultsToResponse(results);
    }
    
    private static List<ProductsResponse> GroupResultsToResponse(IEnumerable<DataResponse> results)
    {
        var groupedResults = (from r in results
            group r by new { r.Item }
            into grp
            select new
            {
                Name = grp.Key,
                Items = grp.ToList()
            }).ToList();

        var prod = (from groupedResult in groupedResults
            let brand = groupedResult.Items.Select(dataResponse => dataResponse.MapToBrand()).ToList()
            select new Product { Name = groupedResult.Name.Item, Brand = brand }).ToList();

        return prod.MapToListOfProductResponse();
    }
}