using Microsoft.AspNetCore.Mvc;
using _02FirstMVCDemo.Injectibles;

namespace _02FirstMVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private  List<Employee> empData;
        private IEmployeeFactory _Factory;

        //c'tor
        public EmployeeController(IEmployeeFactory fact)
        {
            this._Factory = fact;
            
            this.empData = fact.Employees;

        }
        public IActionResult Index()
        {
            return View(this.empData);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id","Name","DateOfJoin","Salary")]Employee newEmp)
        {
            if (ModelState.IsValid)
            {
                this._Factory.Create(newEmp);

            }
            return RedirectToAction("Index");
        }
    }
}
