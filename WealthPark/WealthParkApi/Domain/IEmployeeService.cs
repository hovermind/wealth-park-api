using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WealthParkApi.Models;

namespace WealthParkApi.Domain
{
    /// <summary>
    /// EmployeeService interface
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Gets employees with optional paging and filter
        /// </summary>
        /// <param name="page">No. of the page to fetch (page size : 25 items)</param>
        /// <param name="searchModel">Filter criteria</param>
        /// <returns>Employee DTO list</returns>
        List<EmployeeDto> GetEmployees(int? page, EmployeeSearchModel searchModel);

        /// <summary>
        /// Finds an employee by id
        /// </summary>
        /// <param name="id">Id of the employee to find</param>
        /// <returns>Employee DTO</returns>
        EmployeeDto GetEmployee(long id);

        /// <summary>
        /// Creates employee
        /// </summary>
        /// <param name="employee">Employee to create</param>
        /// <returns>Id of the newly created employee</returns>
        long CreateEmployee(CreateEmployeeDto employee);

        /// <summary>
        /// Updates employee
        /// </summary>
        /// <param name="id">Id of the employee to update</param>
        /// <param name="employee">Employee DTO</param>
        /// <returns>Updated employee DTO</returns>
        EmployeeDto UpdateEmployee(long id, UpdateEmployeeDto employee);

        /// <summary>
        /// Deletes an employee
        /// </summary>
        /// <param name="id">Id of the employee to delete</param>
        void DeleteEmployee(long id);

        /// <summary>
        /// Checks if an employee exists
        /// </summary>
        /// <param name="id">Id of the employee to check</param>
        /// <returns></returns>
        bool EmployeeExists(long id);
    }
}
