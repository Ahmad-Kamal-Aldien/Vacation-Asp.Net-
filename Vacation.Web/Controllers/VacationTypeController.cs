using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Mvc;
using Vacation.Web.Models;

namespace Vacation.Web.Controllers
{
    public class VacationTypeController : Controller
    {
        private  VacationDBContext _db;
        public VacationTypeController(VacationDBContext vacationDBContext)
        {
            _db = vacationDBContext;
        }
        public IActionResult Index()
        {
            return View(_db.vacationTypes.ToList());
        }

        
        public IActionResult GetNames()
        {
            var getData = _db.vacationTypes.ToList();

            return Json(getData);
        }


        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Add(VacationType vacation)
        {
            if (ModelState.IsValid) { 
            _db.vacationTypes.Add(vacation);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vacation);
        }
    }
}
