using Microsoft.AspNetCore.Mvc;
using Vacation.Web.Models;

namespace Vacation.Web.Controllers
{
    public class DashboardController : Controller
    {
        private VacationDBContext _db;
        public DashboardController(VacationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            ViewBag.CountEmp = _db.employees.Count();
            ViewBag.CountDept = _db.departments.Count();
            ViewBag.CountVacationTypes = _db.vacationTypes.Count();
            ViewBag.CountRequestVacation = _db.requestMasterVacations.Count();
            ViewBag.CountEmp = _db.employees.Count();
            return View();
        }
    }
}
