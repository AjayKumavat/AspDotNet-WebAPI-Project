using Delete.Models;
using Delete.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delete.API.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("Get")]
        [Produces(typeof(IEnumerable<Employee>))]
        public async Task<IActionResult> GetEmployee()
        {
            IEnumerable<Employee> employee = await _employeeService.GetEmployeesAsync();
            return Ok(employee);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [Produces(typeof(Employee))]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            Employee employee = await _employeeService.GetEmployeeByIdAsync(id);

            if(employee != null)
                return Ok(employee);

            return NotFound();
        }

        [HttpPost]
        [Route("Add")]
        [Produces(typeof(Employee))]
        public IActionResult AddEmployee(Employee employee)
        {
            return Ok(_employeeService.AddEmployee(employee));
        }

        [HttpPut]
        [Route("Update")]
        [Produces(typeof(Employee))]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            Employee _employee = await _employeeService.UpdateEmployeeAsync(employee);
            return Ok(_employee);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [Produces(typeof(bool))]
        public async Task<bool> DeleteEmployee(int id)
        {
            bool isDeleted = await _employeeService.DeleteEmployeeAsync(id);

            return isDeleted;
        }
    }
}
