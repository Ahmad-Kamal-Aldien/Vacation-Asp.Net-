using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vacation.Web.Models
{
    public class RequestMasterVacation : BaseEntity
    {

        [ForeignKey("Employee")]
        public int EmpId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("VacationType")]
        public int VacationTypeId { get; set; }
        public VacationType VacationType { get; set; }


        [DisplayFormat(DataFormatString ="{0:dd:MM:yyyy}")]
        public DateTime From { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd:MM:yyyy}")]

        public DateTime To { get; set; }
        public bool Approve { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd:MM-yyyy}")]
        public DateTime DateApprove { get; set; }

        public string? Notes { get; set; }
        public List<RequestDetailsVacation> RequestDetailsVacation { get; set; }
    }
}
