using FixaScrew.DataSourceAgg.Common.Contexts;
using FixaScrew.DataSourceAgg.Common.Entities;
using FixaScrew.DataSourceAgg.Common.Enums;
using FixaScrew.DataSourceAgg.Common.Extensions;
using FixaScrew.DataSourceAgg.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace FixaScrew.DataSourceAgg.Services.DatabaseFileStore;
public class DatabaseService : Data<SQLDataStore> , IDatabaseService
{
    private readonly ProductContext _context;
    
    public DatabaseService(ProductContext context) => _context = context;

    public async Task<List<DataResponse>> GetData()
    {
        var initialData = await Pull();
        if(initialData.Any()) Delete();
        
        Create();
        
        return (from sql in await Pull() select sql.MapToDataResponse()).ToList();
    }
    
    public override async Task<List<SQLDataStore>> Pull()
        => await  _context.DataStore.Select(x => x).ToListAsync();

    private async void Create()
    {
        var initialData = new List<SQLDataStore>
        {
            new()
            {
                Id = 1,
                Name = BrandName.Bosch,
                Amount = 1,
                Product = ProductType.Screws,
                StockAmount = 500
            },
            new()
            {
                Id = 2,
                Name = BrandName.Bosch,
                Amount = 1,
                Product = ProductType.Drill,
                StockAmount = 150
            },
            new()
            {
                Id = 3,
                Name = BrandName.BlackDecker,
                Amount = 1,
                Product = ProductType.Sander,
                StockAmount = 3
            },
            new()
            {
                Name = BrandName.Makita,
                Amount = 1,
                Product = ProductType.Screws,
                StockAmount = 1000
            }
        };
        
        await _context.DataStore.AddRangeAsync(initialData);
        await _context.SaveChangesAsync();
    }
    
    private async void Delete()
    {
        foreach (var sqlDataStore in await Pull())
        {
            _context.DataStore.Remove(sqlDataStore);
            await _context.SaveChangesAsync();
        }
    }
}