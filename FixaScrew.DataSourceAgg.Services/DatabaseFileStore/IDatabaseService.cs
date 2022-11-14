using FixaScrew.DataSourceAgg.Common.Models;

namespace FixaScrew.DataSourceAgg.Services.DatabaseFileStore;

public interface IDatabaseService
{ 
    Task<List<DataResponse>> GetData();
}