using FixaScrew.DataSourceAgg.Common.Models;

namespace FixaScrew.DataSourceAgg.Services.CsvFileStore;

public interface ICsvService
{
    Task<List<DataResponse>> GetData();
}