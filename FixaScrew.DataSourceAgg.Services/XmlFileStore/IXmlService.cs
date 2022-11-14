using System.Collections.Generic;
using System.Threading.Tasks;
using FixaScrew.DataSourceAgg.Common.Models;

namespace FixaScrew.DataSourceAgg.Services.XmlFileStore;

public interface IXmlService
{
    Task<List<DataResponse>> GetData();
}