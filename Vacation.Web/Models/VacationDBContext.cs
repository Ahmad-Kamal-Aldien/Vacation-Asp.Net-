using Microsoft.EntityFrameworkCore;

namespace Vacation.Web.Models
{
    public class VacationDBContext:DbContext
    {
        public VacationDBContext(DbContextOptions<VacationDBContext>options):base(options)
        {
            
        }
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }

        public DbSet<RequestMasterVacation> requestMasterVacations { get; set; }
        public DbSet<RequestDetailsVacation> requestDetailsVacations { get;set; }
        public DbSet<VacationType> vacationTypes { get; set; }

    }
}
