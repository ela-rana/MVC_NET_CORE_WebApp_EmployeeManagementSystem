using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private ICRUD crud;

        public EmployeeController(ICRUD crud) //service injection aka dependency injection
        {
            this.crud = crud; //to get reference of CRUD class
        }
        public IActionResult Index()
        {
            //indexviewmodel is a temp model which consists of a list of Employees
            IndexViewModel model = new IndexViewModel();
            model.Employees = crud.GetAllRecords();
            return View(model);
        }
        public IActionResult Details(int? id)
        {
            var emp=crud.GetRecord(id);
            if(emp==null)
                return NotFound(); //NotFound gives a 404 system error- not found
            return View(emp);
        }

        /// <summary>
        /// To add a new employee to the records
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// To edit an employee's record data
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit()
        {
            return View();
        }

    }
}
