using TheplaceEmployeeApp.Data.Entities;
using TheplaceEmployeeApp.Data.Enums;
using TheplaceEmployeeApp.Data.Repositories;
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

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var newEmployee = new Employee()
                {
                    Id = new Guid(),
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    MiddleName = collection["MiddleName"],
                    EmailAddress = collection["EmailAddress"],
                    ResidentialAddress = collection["ResidentialAddress"],
                    SkinColor = Enum.Parse<SkinColor>(collection["SkinColor"]),
                    BranchName = Enum.Parse<BranchName>(collection["BranchName"]),
                    Department = Enum.Parse<Department>(collection["Department"]),
                    Designation = Enum.Parse<Designation>(collection["Designation"]),
                    StateName = Enum.Parse<StateName>(collection["StateName"]),
                    Age = int.Parse(collection["Age"]),
                    PhoneNumber = int.Parse(collection["PhoneNumber"]),
                  //DateEmployed = DateTime.Now,
                  //DateOfBirth = DateTime.Now
                };
                _employeeRepository.CreateEmployee(newEmployee);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
