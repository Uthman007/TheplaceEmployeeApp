using TheplaceEmployeeApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TheplaceEmployeeApp.Data.Repositories
{
    public interface IEmployeeRepository
    {
        public void CreateEmployee(Employee newEmployee);

        public void UpdateEmployee(Employee employee);

        public void DeleteEmployee(Guid EmployeeId);

        public Employee GetEmployee(Guid EmployeeId);

        public IEnumerable<Employee> GetAllEmployees();
    }
}
