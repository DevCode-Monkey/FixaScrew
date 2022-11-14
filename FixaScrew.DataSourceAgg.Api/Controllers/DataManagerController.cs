using FixaScrew.DataSourceAgg.Common.Models;
using FixaScrew.DataSourceAgg.Services;
using Microsoft.AspNetCore.Mvc;

namespace FixaScrew.DataSourceAgg.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DataManagerController : ControllerBase
{
    private readonly ILogger<DataManagerController> _logger;
    private readonly IDataStoreService _dataStoreService;
    
    public DataManagerController(
        ILogger<DataManagerController> logger,
        IDataStoreService dataStoreService
        )
    {
        _logger = logger;
        _dataStoreService = dataStoreService;
    }

    [HttpGet(Name = "DataPull")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<ProductsResponse>> DataPull() => await _dataStoreService.PollDataStores();
}