using Delete.Database.Repository;
using Delete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delete.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Employee AddEmployee(Employee employee);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee AddEmployee(Employee employee)
        {
            _employeeRepository.Add(employee);
            return employee;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            Employee employee = await GetEmployeeByIdAsync(id);

            if (employee != null)
            {
                _employeeRepository.Delete(employee);
                return true;
            }

            return false;
                
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetById(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _employeeRepository.Get();
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            Employee _employee = await GetEmployeeByIdAsync(employee.Id);

            if(_employee != null)
            {
                _employee.Name = employee.Name;
                _employee.Designation = employee.Designation;
                _employeeRepository.Update(_employee);
            }

            return _employee;
        }
    }
}
