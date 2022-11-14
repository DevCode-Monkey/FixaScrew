using FixaScrew.DataSourceAgg.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FixaScrew.DataSourceAgg.Common.Context;

public class DataContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<SQLDataStore> DataStore { get; set; }

    public DataContext(IConfiguration configuration) => _configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder options) 
        => options.UseSqlite(_configuration.GetConnectionString("SQLDataStore"));
}