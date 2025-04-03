using System.ComponentModel.DataAnnotations;

namespace Vacation.Web.Models
{
    public class Department: BaseEntity
    {
        [StringLength(100)]

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; }=string.Empty;

    }
}
