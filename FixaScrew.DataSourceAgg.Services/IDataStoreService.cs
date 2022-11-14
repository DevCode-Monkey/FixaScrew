using System.Collections.Generic;
using System.Threading.Tasks;
using FixaScrew.DataSourceAgg.Common.Models;

namespace FixaScrew.DataSourceAgg.Services;

public interface IDataStoreService
{
    Task<List<ProductsResponse>> PollDataStores();
}