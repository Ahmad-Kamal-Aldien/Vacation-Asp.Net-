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
             //< th scope = "col" > Employee Name </ th >
             //               < th scope = "col" > Request Date </ th >
             //               < th scope = "col" > Vacations </ th >
             //               < th scope = "col" > Comments </ th >
             //               < th scope = "col" > Approve </ th >
             //               < th scope = "col" > Events </ th >


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
            //requestDetailsVacation.MasterVacation.Id = 10;



            for (DateTime i = requestDetailsVacation.MasterVacation.From; i < requestDetailsVacation.MasterVacation.To;
                i=i.AddDays(1))
            {

                ////يومه في الاسبوع ايه
                //if (Array.IndexOf(days, (int)i.DayOfWeek) != -1)
                //{
                //    requestDetailsVacation.Id = 0;
                //    requestDetailsVacation.VacationDate = i;
                //    _db.requestDetailsVacations.Add(requestDetailsVacation);
                //    _db.SaveChanges();
                //}


                //يومه في الاسبوع ايه
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



        public IActionResult Edit()
        {
            return View();
        }

       

        

    }
}
