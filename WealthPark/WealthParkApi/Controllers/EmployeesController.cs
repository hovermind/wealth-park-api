using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WealthParkApi.Domain;
using WealthParkApi.Models;

namespace WealthParkApi.Controllers
{
    /// <summary>
    /// Employees API controller class.
    /// </summary>
    [ApiController]
    [Route("employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        /// <summary>
        /// Employees API controller class constructor.
        /// </summary>
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Returns all employees
        /// </summary>
        /// <para>Ppagination and filtering are enabled. By default it will send all employees if page and search query params are not set</para>
        /// <param name="page">No. of the page to fetch</param>
        /// <param name="searchModel">Optional search criteria</param>
        /// <returns>List of employees</returns>
        /// <response code="200">Returns employee list</response> 
        [HttpGet(Name = "EmployeesRoute")]
        public ActionResult<IEnumerable<EmployeeDto>> GetEmployees([FromQuery]int? page, [FromQuery]EmployeeSearchModel searchModel)
        {
            return _employeeService.GetEmployees(page, searchModel);
        }

        /// <summary>
        /// Returns employee for specified id
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns>List of employees</returns>
        /// <response code="200">Employee for the given id</response> 
        [HttpGet("{id}", Name = "GetEmployeeByIdRoute")]
        public ActionResult<EmployeeDto> GetEmployee([FromRoute]int id)
        {
            return _employeeService.GetEmployee(id);
        }

        /// <summary>
        /// Creates an employee
        /// </summary>
        /// <param name="employee">Employee DTO</param>
        /// <returns>Id of the newly created employee</returns>
        /// <response code="201">Employee created</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        public IActionResult Post([FromBody] CreateEmployeeDto employee)
        {
            var id = _employeeService.CreateEmployee(employee);

            return CreatedAtRoute("GetEmployeeByIdRoute", new { id }, new { id });
        }

        /// <summary>
        /// Updates an employee for specified id
        /// </summary>
        /// <param name="id">Id of the employee to update</param>
        /// <param name="employee">Employee DTO</param>
        /// <returns>Updated employee</returns>
        /// <response code="200">Employee updated</response>
        /// <response code="404">No employee found for given id</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("{id}")]
        public ActionResult<EmployeeDto> Put([FromRoute] int id, [FromBody] UpdateEmployeeDto employee)
        {
            return _employeeService.UpdateEmployee(id, employee);
        }

        /// <summary>
        /// Deletes an employee for specified id
        /// </summary>
        /// <param name="id">Id of the employee to delete</param>
        /// <returns>Updated employee</returns>
        /// <response code="204">Employee deleted</response>
        /// <response code="404">No employee found for given id</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            _employeeService.DeleteEmployee(id);

            return NoContent();
        }
    }
}
