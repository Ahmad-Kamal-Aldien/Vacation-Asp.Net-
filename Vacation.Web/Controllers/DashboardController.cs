using Microsoft.AspNetCore.Mvc;

namespace Vacation.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
