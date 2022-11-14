using System.Xml.Linq;
using FixaScrew.DataSourceAgg.Common.Enums;
using FixaScrew.DataSourceAgg.Common.Extensions;
using FixaScrew.DataSourceAgg.Common.Models;
using Microsoft.Extensions.Options;

namespace FixaScrew.DataSourceAgg.Services.XmlFileStore;
public class XmlService :  Data<XmlResponse>, IXmlService
{
    private readonly DataLocationOptions _xml;

    public XmlService(IOptionsSnapshot<DataLocationOptions> options) 
        => _xml = options.Get(DataLocationOptions.Xml);

    public async Task<List<DataResponse>> GetData()
        => (from xml in await Pull() select xml.MapToDataResponse()).ToList();

    public override async Task<List<XmlResponse>> Pull()
    {
        var file = Path.Combine(_xml.BaseDirectory, _xml.Location);

        await using var stream = File.OpenRead(Path.GetFullPath(file));

        // Loading from a file, you can also load from a stream
        var xml = XElement.Load(stream);

        // Query the data and write out a subset of contacts
        var query = from c in xml.Descendants("BRAND")
            select new
            {
                NameOfBrand = c.Element("NameOfBrand").Value,
                Item = c.Element("Item").Value,
                Pricing = c.Element("Pricing").Value,
                Inventory = c.Element("Inventory").Value
            };

        var result = new List<XmlResponse>();

        foreach (var element in query)
        {
            if (!Enum.TryParse(element.NameOfBrand, out BrandName brand)) continue;
            if (!Enum.TryParse(element.Item, out ProductType product)) continue;
            if (!decimal.TryParse(element.Pricing, out var cost)) continue;
            if (!int.TryParse(element.Inventory, out var totalItems)) continue;
            result.Add(new XmlResponse
            {
                NameOfBrand = brand,
                Items = product,
                Pricing = cost,
                Inventory = totalItems
            });
        }
        
        return result;
    }
}