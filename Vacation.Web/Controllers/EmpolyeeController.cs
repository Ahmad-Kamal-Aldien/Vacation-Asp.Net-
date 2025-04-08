using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacation.Web.Models;

namespace Vacation.Web.Controllers
{
    public class EmpolyeeController : Controller
    {
       private VacationDBContext _dp;
        public EmpolyeeController(VacationDBContext vacationDBContext)
        {
            _dp = vacationDBContext;
        }
        public IActionResult Index()
        {
            return View(_dp.employees.Include(x=>x.Department).ToList());
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Department = _dp.departments.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee Emp)
        {
            if (ModelState.IsValid) { 
            
                _dp.employees.Add(Emp);
                _dp.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Emp);
        }


        public IActionResult GetNames( string name)
        {
            var getData = _dp.employees.Where(x => x.Name.Contains(name)).ToList();

            return Json(getData);
        }


        

    }
}
