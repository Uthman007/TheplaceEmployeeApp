using TheplaceEmployeeApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TheplaceEmployeeApp.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateEmployee(Employee newEmployee)
        {
            _context.Employees.Add(newEmployee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(Guid employeeId)
        {
            var employeeToDelete = _context.Employees.Find(employeeId);

            // TODO: Check that the book actually exists, and handle null (not found) case

            if (employeeToDelete != null)
            {
                _context.Employees.Remove(employeeToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployee(Guid employeeId)
        {
            // TODO: Check that the book actually exists, and handle null (not found) case
            return _context.Employees.Find(employeeId);
        }

        public void UpdateEmployee(Employee employee)
        {
            if (employee != null)
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.Update(employee);
                _context.SaveChanges();
            }
        }
    }
}
