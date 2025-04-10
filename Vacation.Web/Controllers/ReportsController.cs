using Microsoft.AspNetCore.Mvc;

namespace Vacation.Web.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
