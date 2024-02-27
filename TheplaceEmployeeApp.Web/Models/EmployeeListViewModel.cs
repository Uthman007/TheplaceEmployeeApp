using TheplaceEmployeeApp.Data.Entities;
using System.ComponentModel;



namespace TheplaceEmployeeApp.Web.Models
{
    public class EmployeeListViewModel
    {
        [DisplayName("Search")]
        public string SearchTerm { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
