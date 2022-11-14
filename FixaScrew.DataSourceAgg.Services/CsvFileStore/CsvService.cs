using FixaScrew.DataSourceAgg.Common.Enums;
using FixaScrew.DataSourceAgg.Common.Extensions;
using FixaScrew.DataSourceAgg.Common.Models;
using Microsoft.Extensions.Options;

namespace FixaScrew.DataSourceAgg.Services.CsvFileStore;
public class CsvService : Data<CsvResponse>, ICsvService
{
    private readonly DataLocationOptions _csv;

    public CsvService(IOptionsSnapshot<DataLocationOptions> options) 
        => _csv = options.Get(DataLocationOptions.Csv);

    public async Task<List<DataResponse>> GetData() 
        => (from csv in await Pull() select csv.MapToDataResponse()).ToList();
    
    public override async Task<List<CsvResponse>> Pull()
    {
        var file = Path.Combine(_csv.BaseDirectory, _csv.Location);
        var stream = File.OpenRead(Path.GetFullPath(file));

        var result = new List<CsvResponse>();

        using var reader = new StreamReader(stream);
        while (await reader.ReadLineAsync() is { } row)
        {
            if (!ValidateInputs(row)) continue;
            var columns = row.Split(',');
            Enum.TryParse(columns[0], out BrandName brand);
            Enum.TryParse(columns[1], out ProductType item);
            result.Add(new CsvResponse
            {
                Name = brand,
                Item = item,
                Cost = Convert.ToDecimal(columns[2]),
                TotalItems = Convert.ToInt16(columns[3])
            });
        }

        return result;
    }

    private static bool ValidateInputs(string input)
    {
        var columns = input.Split(',');

        if (!Enum.TryParse(columns[0], out BrandName _))
            return false;

        if (!Enum.TryParse(columns[1], out ProductType _))
            return false;

        return decimal.TryParse(columns[2], out _) && int.TryParse(columns[3], out _);
    }
}