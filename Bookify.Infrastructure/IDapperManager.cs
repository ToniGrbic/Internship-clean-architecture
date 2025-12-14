using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Infrastructure
{
    public interface IDapperManager
    {
        Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object? param = null);
        Task<T?> QuerySingleAsync<T>(string sql, object? param = null);
        Task ExecuteAsync(string sql, object? param = null);
    }

}
