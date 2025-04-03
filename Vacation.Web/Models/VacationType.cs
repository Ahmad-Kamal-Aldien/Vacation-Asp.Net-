namespace Vacation.Web.Models
{
    public class VacationType: BaseEntity
    {

        public string Name { get; set; }=string.Empty;
        public string Color { get; set; } = string.Empty;
        public int NumberOfDays { get; set; }
    }
}
