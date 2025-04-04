using Microsoft.AspNetCore.Mvc;
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
            return View(_dp.employees.ToList());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
