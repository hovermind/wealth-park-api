using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WealthParkApi.Domain.Entities;

namespace WealthParkApi.Domain
{
    /// <summary>
    /// Employee DbContext
    /// </summary>
    public class EmployeeDbContext : DbContext
    {
        /// <summary>
        /// DbContext ctor for DI
        /// </summary>
        /// <param name="options"></param>
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Employees DB set
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
    }
}
