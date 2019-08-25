using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using WealthParkApi.Domain;

namespace WealthParkApi.Test.RepositoryTest
{
    public class EmployeeRepositoryTestFixture : IDisposable
    {
        public DbContextOptions<EmployeeDbContext> DbContextOptions { get; private set; }
        private SqliteConnection _connection;

        public EmployeeRepositoryTestFixture()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connectionString = connectionStringBuilder.ToString();
            _connection = new SqliteConnection(connectionString);
            //_connection.Open();

            // create in-memory context
            var builder = new DbContextOptionsBuilder<EmployeeDbContext>();
            builder.UseSqlite(_connection); //builder.UseInMemoryDatabase(databaseName: "wealthpark");

            DbContextOptions = builder.Options;
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
