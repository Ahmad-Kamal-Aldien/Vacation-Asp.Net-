using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacation.Web.Models;

namespace Vacation.Web.Controllers
{
    public class ReportsController : Controller
    {
        private VacationDBContext _db;
        public ReportsController(VacationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ViewBag.Emps = _db.employees.ToList();
            return View();
        }

        public IActionResult GetData(int Id,DateTime from,DateTime to)
        {
            string id = $"and E.Id={Id} ";

            string sqlquery = $@"select distinct  E.Id,E.Name,E.CountDayVacation,
                        sum (VT.NumberOfDays) As Total,
                        E.CountDayVacation- sum (VT.NumberOfDays) as Remain
                        from employees E,
                        requestMasterVacations RMV,
                        requestDetailsVacations RDV,
                        vacationTypes VT
                        where  RMV.Approve='True' 
                        and RDV.VacationDate
                        between ' { from} '
                        and ' {to} '{id}
                        and E.Id=RMV.EmpId and VT.Id=RMV.VacationTypeId and RMV.Id=RDV.MasterVacationId
                        group by RDV.MasterVacationId,E.Id,
                        E.Name,E.CountDayVacation";

                 var data= _db.ReportViewModels.FromSqlRaw(sqlquery).ToList();
            ViewBag.Emps = _db.employees.ToList();
            return View("Index", data);
        }


    }
}
