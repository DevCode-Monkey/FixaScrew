namespace FixaScrew.DataSourceAgg.Services;

public abstract class Data<T>
{
    public abstract Task<List<T>> Pull();
}