using FixaScrew.DataSourceAgg.Common.Models;
using FixaScrew.DataSourceAgg.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FixaScrew.DataSourceAgg.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DataManagerController : ControllerBase
{
    private readonly IDataStoreService _dataStoreService;
    
    public DataManagerController(IDataStoreService dataStoreService) => _dataStoreService = dataStoreService;

    [HttpGet]
    [SwaggerOperation(Summary = "Query the data stores",
        Description = "Pull data from the data stores and aggregate grouped by the product name")]
    [SwaggerResponse(200, "A perfect result!", typeof(IEnumerable<ProductsResponse>))]
    [SwaggerResponse(400, "Well - something wasn't quite right! ")]
    public async Task<IActionResult> DataPull() => Ok(await _dataStoreService.PollDataStores());
}