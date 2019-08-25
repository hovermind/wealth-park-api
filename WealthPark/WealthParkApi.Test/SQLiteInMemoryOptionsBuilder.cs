using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WealthParkApi.Test
{
    /// <summary>
    /// DbContext option bulder for SQLite in-memory DB
    /// </summary>
    public class SQLiteInMemoryOptionsBuilder
    {
        /// <summary>
        /// Creates DbContext option for SQLite in-memory DB
        /// </summary>
        /// <typeparam name="T">Type of DbContext</typeparam>
        /// <param name="throwOnClientServerWarning"></param>
        /// <returns></returns>
        public static DbContextOptions<T> CreateOptions<T>(bool throwOnClientServerWarning = true) where T : DbContext
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            connection.Open();

            // create in-memory context
            var builder = new DbContextOptionsBuilder<T>();
            builder.UseSqlite(connection);
            //builder.ApplyOtherOptionSettings(throwOnClientServerWarning);
            return builder.Options;
        }
    }
}
