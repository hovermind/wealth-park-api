using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WealthParkApi.Domain.Entities;
using WealthParkApi.Filters;
using WealthParkApi.Models;

namespace WealthParkApi.Domain
{
    /// <summary>
    /// Interface for DI of employee repository
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Get all employees with search filter only
        /// </summary>
        /// <param name="searchModel">Search criteria model</param>
        /// <param name="searchFieldMutators">Query mutator to apply logic dynamically</param>
        /// <returns>Employee entity list</returns>
        IEnumerable<Employee> GetAll(EmployeeSearchModel searchModel, List<SearchFieldMutator<Employee, EmployeeSearchModel>> searchFieldMutators);

        /// <summary>
        /// Get all employees with search filter and paging
        /// </summary>
        /// <param name="skipSize">Nunmber of items to skip</param>
        /// <param name="takeSize">Number of items to take</param>
        /// <param name="searchModel">Search criteria model</param>
        /// <param name="searchFieldMutators">Query mutator to apply logic dynamically</param>
        /// <returns>Employee entity list</returns>

        IEnumerable<Employee> GetAll(int skipSize, int takeSize, EmployeeSearchModel searchModel, List<SearchFieldMutator<Employee, EmployeeSearchModel>> searchFieldMutators);
        /// <summary>
        /// Get a single entity by id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity</returns>
        Employee Get(long id);

        /// <summary>
        /// Add an entity
        /// </summary>
        /// <param name="newEntity">Entity to create</param>
        /// <returns>Id of newly created entity</returns>
        long Add(Employee newEntity);

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="modifiedEntity">Entity to modify</param>
        void Update(Employee modifiedEntity);

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="entityToDelete">Entity to delete</param>
        void Delete(Employee entityToDelete);
    }
}
