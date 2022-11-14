using FixaScrew.DataSourceAgg.Common.Models;

namespace FixaScrew.DataSourceAgg.Services.JsonFileStore;

public interface IJsonService
{
    Task<List<DataResponse>> GetData();
}