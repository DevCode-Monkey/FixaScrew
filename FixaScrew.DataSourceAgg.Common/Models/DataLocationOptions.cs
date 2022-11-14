namespace FixaScrew.DataSourceAgg.Common.Models;

public class DataLocationOptions
{
    public const string Xml = "Xml";
    public const string Csv = "Csv";
    public const string Json = "Json";
    public string Location { get; set; } = string.Empty;
    public string BaseDirectory { get; } = AppDomain.CurrentDomain.BaseDirectory;
}