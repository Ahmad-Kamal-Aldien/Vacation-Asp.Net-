using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vacation.Web.Models
{
    public class RequestDetailsVacation : BaseEntity
    {
        [ForeignKey("MasterVacation")]
        public int MasterVacationId { get; set; }

        public RequestMasterVacation MasterVacation { get; set; }
    

        [DisplayFormat(DataFormatString ="{0:dd:MM:yyyy}")]
        public DateTime VacationDate { get; set; }



    }
}
