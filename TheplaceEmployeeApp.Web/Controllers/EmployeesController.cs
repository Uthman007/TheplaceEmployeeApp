using TheplaceEmployeeApp.Data.Entities;
using TheplaceEmployeeApp.Data.Enums;
using TheplaceEmployeeApp.Data.Repositories;
using TheplaceEmployeeApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace TheplaceEmployeeApp.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: EmployeesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmployeesController/List
        [Route("Employees/view-all")]
        public ActionResult List(string? searchTerm)
        {
            var employeelistViewModel = new EmployeeListViewModel();

            var employeesToDisplay = _employeeRepository.GetAllEmployees();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                employeelistViewModel.Employees = employeesToDisplay;
                employeelistViewModel.SearchTerm = string.Empty;
                return View("ViewAll", employeelistViewModel);
            }
            else
            {
                var filteredEmployees = employeesToDisplay.Where(b => b.FirstName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)
                                                           || b.LastName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase));
                employeelistViewModel.Employees = filteredEmployees;
                employeelistViewModel.SearchTerm = searchTerm;
                return View("ViewAll", employeelistViewModel);
            }
        }

        // GET: BooksController/Details/some-guid-value
        [Route("employees/details/{id}")]
        public ActionResult Details(Guid id)
        {
            var employeeToDisplay = _employeeRepository.GetEmployee(id);

            if (employeeToDisplay == null)
            {
                return NotFound();
            }

            return View(employeeToDisplay);
        }

        // GET: EmployeesController/Create
        [Route("employees/create")]
        public ActionResult Create()
        {
            var newEmployee = new Employee(); // In future, define a ViewModel for this purpose
            return View(newEmployee);
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("employees/create")]
        public ActionResult Create(Employee postedEmployee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var newEmployee = new Employee()
                {
                    Id = Guid.NewGuid(),
                    FirstName = postedEmployee.FirstName,
                    LastName = postedEmployee.LastName,
                    MiddleName = postedEmployee.MiddleName,
                    EmailAddress = postedEmployee.EmailAddress,
                    ResidentialAddress = postedEmployee.ResidentialAddress,
                    SkinColor = postedEmployee.SkinColor,
                    BranchName = postedEmployee.BranchName,
                    Department = postedEmployee.Department,
                    Designation = postedEmployee.Designation,
                    StateName = postedEmployee.StateName,
                    Age = postedEmployee.Age,
                    PhoneNumber = postedEmployee.PhoneNumber,
                    DateEmployed = postedEmployee.DateEmployed,
                    DateOfBirth = postedEmployee.DateOfBirth
                };
                _employeeRepository.CreateEmployee(newEmployee);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: EmployeesController/Edit/some-guid-value
        [Route("employees/edit/{id}")]
        public ActionResult Edit(Guid id)
        {
            var employeeToUpdate = _employeeRepository.GetEmployee(id);
            if (employeeToUpdate == null)
            {
                return NotFound();
            }

            return View(employeeToUpdate);
        }

        [HttpPost, Route("employees/edit/{id}"), ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Employee postedEmployee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                if (id != postedEmployee.Id)
                {
                    return BadRequest();
                }

                //postedEmployee.Updated = DateTime.Now;
                _employeeRepository.UpdateEmployee(postedEmployee);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Delete/some-guid-value
        [Route("employees/delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            var employeeToDelete = _employeeRepository.GetEmployee(id);
            if (employeeToDelete == null)
            {
                return NotFound();
            }
            return View(employeeToDelete);
        }

        // POST: EmployeesController/Delete/some-guid-value
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("employees/delete/{id}")]
        public ActionResult ConfirmDelete(Guid id)
        {
            try
            {
                var employeeToDelete = _employeeRepository.GetEmployee(id);
                if (employeeToDelete == null)
                {
                    return NotFound();
                }

                _employeeRepository.DeleteEmployee(id);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }

        }
    }
}
