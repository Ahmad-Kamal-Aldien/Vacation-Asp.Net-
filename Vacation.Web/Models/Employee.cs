using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vacation.Web.Models
{
    public class Employee : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public Department Department { get; set; }

        [Range(1,31)]
        public int CountDayVacation { get; set; }
    }
}
