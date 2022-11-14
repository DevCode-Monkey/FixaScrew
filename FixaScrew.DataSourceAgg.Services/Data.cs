﻿using System.Collections.Generic;
using System.Threading.Tasks;
using FixaScrew.DataSourceAgg.Services.JsonFileStore;

namespace FixaScrew.DataSourceAgg.Services;

public abstract class Data<T>
{
    public abstract Task<List<T>> Pull();
}