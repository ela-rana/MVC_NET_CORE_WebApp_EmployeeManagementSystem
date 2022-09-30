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
        public IActionResult Create() //By default methods are Get type 
        {
            return View();
        }

        [HttpPost] //we have to specify that it is a Post type otherwise by default it is Get
        public IActionResult Create(Employee obj) //Here we method overload to create its post type 
        {
            if (ModelState.IsValid)
            {
                crud.AddRecord(obj);
                ViewBag.Message = "Employee added successfully";
            }
            return View(obj); //to stay on this screen after employee created
            
            //to go back to list after record created you can return the following instead
            //but if you don't stay on the create page you don't see error message left if there 
            //are create issues (like form fields entered incorrectly
            //return RedirectToRoute(new {Action="Index", Controller="Employee"}); 
            
        }

        /// <summary>
        /// To edit an employee's record data
        /// </summary>
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var emp = crud.GetRecord(id);
            if (emp == null)
                return NotFound(); //NotFound gives a 404 system error- not found
            return View(emp);
        }
        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                crud.UpdateRecord(obj);
                return RedirectToAction("Index"); //we are only passing action, not controller 
                         //because if its within the same controller you don't have to specify
            }
            //else part: if we didn't return yet
            ViewBag.Message = "Error editing employee";
            return View(obj);
        }

        /// <summary>
        /// To delete an employee's record data
        /// </summary>
        public IActionResult Delete(int? id)
        {
            crud.DeleteRecord(id);
            return RedirectToAction("Index");

            //return View("Index"); //cannot do this because you have to pass the employee
                //list to the index, otherwise it has no data to load its content
                //you have to redirect to the index action method first to generate the
                //list and then open the index view
        }
    }
}
