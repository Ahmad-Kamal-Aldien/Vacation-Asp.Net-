using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacation.Web.Models;
using static System.Formats.Asn1.AsnWriter;

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
           


            return View(_db.requestMasterVacations.Include(x=>x.Employee).Include(x=>x.VacationType).ToList());
        }

        [HttpGet]
        public IActionResult RequestVacation()
        {
           

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RequestVacation(RequestDetailsVacation requestDetailsVacation, int[]days
            )
        {
          
            for (DateTime i = requestDetailsVacation.MasterVacation.From; i < requestDetailsVacation.MasterVacation.To;
                i=i.AddDays(1))
            {
                if (Array.IndexOf(days, (int)i.DayOfWeek)!=-1 )
                {
                    requestDetailsVacation.Id = 0;
                    requestDetailsVacation.VacationDate = i;
                    _db.requestDetailsVacations.Add(requestDetailsVacation);
                    _db.SaveChanges();
                }




            }

            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _db.requestMasterVacations.Where(x => x.Id == id).Include(x => x.Employee).Include(x => x.RequestDetailsVacation).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        //If I Want Edit In One Value Only
        public IActionResult Edit(RequestMasterVacation requestMasterVacation)
        {
      
            if (requestMasterVacation.Approve == true)
            {
                _db.Attach(requestMasterVacation);
                requestMasterVacation.Approve = true;
                _db.Entry(requestMasterVacation).Property(x=>x.Approve).IsModified=true;

         
                _db.SaveChanges();
            }
          
           
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
        {
            return View();
        }



    }
}
