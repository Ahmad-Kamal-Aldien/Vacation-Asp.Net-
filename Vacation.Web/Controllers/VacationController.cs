using Microsoft.AspNetCore.Mvc;
using Vacation.Web.Models;

namespace Vacation.Web.Controllers
{
    public class VacationController : Controller
    {
        private VacationDBContext _db;
        public VacationController(VacationDBContext vacationDBContext)
        {
            _db = vacationDBContext;    
        }
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
