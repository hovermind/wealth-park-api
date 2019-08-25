using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WealthParkApi.Domain;
using WealthParkApi.Domain.Entities;
using WealthParkApi.Exceptions;
using WealthParkApi.Filters;
using WealthParkApi.Models;
using WealthParkApi.Utils;

namespace WealthParkApi.Services
{
    /// <summary>
    /// Employee services class (contains all business logic)
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _autoMapper;

        /// <inheritdoc/>
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper autoMapper)
        {
            _employeeRepository = employeeRepository;
            _autoMapper = autoMapper;
        }

        /// <inheritdoc/>
        public List<EmployeeDto> GetEmployees(int? page, EmployeeSearchModel searchModel)
        {
            IEnumerable<Employee> employeeEntities;

            // filter criteria - statregy design pattern
            var searchFieldMutators = new List<SearchFieldMutator<Employee, EmployeeSearchModel>>();
            searchFieldMutators.Add(new SearchFieldMutator<Employee, EmployeeSearchModel>(search => !string.IsNullOrWhiteSpace(search.FirstName), (query, search) => query.Where(e => e.FirstName.Contains(search.FirstName))));
            searchFieldMutators.Add(new SearchFieldMutator<Employee, EmployeeSearchModel>(search => !string.IsNullOrWhiteSpace(search.LastName), (query, search) => query.Where(e => e.FirstName.Contains(search.LastName))));

            if (page.HasValue && page.Value >= 1)
            {
                var skipSize = AppConstants.PageSize * (page.Value - 1);
                var takeSize = AppConstants.PageSize;
                employeeEntities = _employeeRepository.GetAll(skipSize, takeSize, searchModel, searchFieldMutators);
            }
            else
            {
                employeeEntities = _employeeRepository.GetAll(searchModel, searchFieldMutators);
            }

            var employeeDtoList = _autoMapper.Map<List<EmployeeDto>>(employeeEntities);

            return employeeDtoList;
        }

        /// <inheritdoc/>
        public EmployeeDto GetEmployee(long id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee != null)
            {
                return _autoMapper.Map<EmployeeDto>(employee);
            }
            else
            {
                throw new ApiException(StatusCodes.Status404NotFound, $"Employee for the id {id} does not exist");
            }
        }

        /// <inheritdoc/>
        public long CreateEmployee(CreateEmployeeDto employee)
        {
            var newEmployee = _autoMapper.Map<Employee>(employee);

            var newEmployeeId = _employeeRepository.Add(newEmployee);

            return newEmployeeId;
        }

        /// <inheritdoc/>
        public EmployeeDto UpdateEmployee(long id, UpdateEmployeeDto employeeDto)
        {
            var employeeToUpdate = _employeeRepository.Get(id);
            if (employeeToUpdate != null)
            {
                try
                {
                    var modified = _autoMapper.Map<Employee>(employeeDto);

                    _autoMapper.Map(modified, employeeToUpdate);

                    _employeeRepository.Update(employeeToUpdate);

                    var dtoToReturn = _autoMapper.Map<EmployeeDto>(employeeToUpdate);

                    return dtoToReturn;
                }
                catch (Exception e)
                {

                    throw new ApiException(StatusCodes.Status500InternalServerError, $"Failed to update employee for the id {id}");
                }
            }
            else
            {
                throw new ApiException(StatusCodes.Status404NotFound, $"Employee for the id {id} does not exist");
            }
        }

        /// <inheritdoc/>
        public void DeleteEmployee(long id)
        {
            var employeeToDelete = _employeeRepository.Get(id);
            if (employeeToDelete != null)
            {
                try
                {
                    _employeeRepository.Delete(employeeToDelete);
                }
                catch (Exception e)
                {

                    throw new ApiException(StatusCodes.Status500InternalServerError, $"Failed to delete employee for the id {id}.");
                }
            }
            else
            {
                throw new ApiException(StatusCodes.Status404NotFound, $"Employee for the id {id} does not exist");
            }
        }

        /// <inheritdoc/>
        public bool EmployeeExists(long id) => _employeeRepository.Get(id) != null;
    }
}
