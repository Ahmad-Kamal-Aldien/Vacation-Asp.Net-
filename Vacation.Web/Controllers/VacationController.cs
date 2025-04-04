using Microsoft.AspNetCore.Mvc;

namespace Vacation.Web.Controllers
{
    public class VacationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RequestVacation()
        {
            return View();
        }


        
        public IActionResult Edit()
        {
            return View();
        }

    }
}
