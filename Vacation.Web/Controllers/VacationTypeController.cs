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

        public IActionResult Add()
        {
            return View();
        }
    }
}
