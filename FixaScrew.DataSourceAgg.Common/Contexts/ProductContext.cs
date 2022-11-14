using FixaScrew.DataSourceAgg.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FixaScrew.DataSourceAgg.Common.Contexts;

public class ProductContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<SQLDataStore> DataStore { get; set; }

    public ProductContext(IConfiguration configuration) => _configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder options) 
        => options.UseSqlite(_configuration.GetConnectionString("SQLDataStore"));
}