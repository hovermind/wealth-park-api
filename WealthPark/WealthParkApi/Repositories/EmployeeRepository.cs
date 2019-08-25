using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WealthParkApi.Domain;
using WealthParkApi.Domain.Entities;
using WealthParkApi.Filters;
using WealthParkApi.Models;

namespace WealthParkApi.Repositories
{
    /// <summary>
    /// Implementation of generic repository for employee
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly EmployeeDbContext _context;

        /// <inheritdoc/>
        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IEnumerable<Employee> GetAll(EmployeeSearchModel searchModel, List<SearchFieldMutator<Employee, EmployeeSearchModel>> searchFieldMutators)
        {
            var query = _context.Employees.AsQueryable();

            foreach (var searchFieldMutator in searchFieldMutators)
            {
                query = searchFieldMutator.Apply(searchModel, query);
            }

            return query.OrderBy(e => e.Id).AsEnumerable();
        }

        /// <inheritdoc/>
        public IEnumerable<Employee> GetAll(int skipSize, int takeSize, EmployeeSearchModel searchModel, List<SearchFieldMutator<Employee, EmployeeSearchModel>> searchFieldMutators)
        {
            var query = GetAll(searchModel, searchFieldMutators);
            return query.Skip(skipSize).Take(takeSize).AsEnumerable();
        }

        /// <inheritdoc/>
        public Employee Get(long id)
        {
            return _context.Employees.Find(id);
        }

        /// <inheritdoc/>
        public long Add(Employee newEmployee)
        {
            _context.Employees.Add(newEmployee);
            _context.SaveChanges();

            return newEmployee.Id;
        }

        /// <inheritdoc/>
        public void Update(Employee employeeToUpdate)
        {
            _context.Employees.Update(employeeToUpdate);
            _context.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(Employee employeeToDelete)
        {
            _context.Employees.Remove(employeeToDelete);  //_context.Remove<Employee>(new Employee { Id = id });
            _context.SaveChanges();
        }
    }
}
