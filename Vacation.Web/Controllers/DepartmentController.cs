using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Vacation.Web.Models;

namespace Vacation.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private VacationDBContext _db;
        public DepartmentController(VacationDBContext vacationDBContext)
        {
            _db = vacationDBContext;
        }
        //To Get All
        public IActionResult Index()
        {
            
            return View(_db.departments.ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Department department)
        {
            if (ModelState.IsValid) { 
            
                _db.Add(department);
                _db.SaveChanges();  
                return RedirectToAction("Index");
            }
            return View(department);
        }

        
        
        public IActionResult Details(int id)
        {
            if (ModelState.IsValid)
            {

               var model=_db.departments.FirstOrDefault(x => x.Id == id);
               
            }
            return View();
        }




        //
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid) {

                _db.Update(department);
                _db.SaveChanges();
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {

                var model = _db.departments.FirstOrDefault(x => x.Id == id);
                if (model != null) {
                    _db.departments.Remove(model);
                    _db.SaveChanges();
                }
                

            }
            return View();
        }





    }

   
  
}
