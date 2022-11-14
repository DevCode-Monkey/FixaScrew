using FixaScrew.DataSourceAgg.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace FixaScrew.DataSourceAgg.Api.Extensions;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DbSet<SQLDataStore> DataStore { get; set; }

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(Configuration.GetConnectionString("SQLDataStore"));
    }
}