using Microsoft.EntityFrameworkCore;

namespace Vacation.Web.Models
{
    public class VacationDBContext:DbContext
    {
        public VacationDBContext(DbContextOptions<VacationDBContext>options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //GetReportViewModel Name Of Model

            modelBuilder.Entity<GetReportViewModel>().HasNoKey().ToSqlQuery("GetReportViewModel");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<GetReportViewModel>ReportViewModels { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }

        public DbSet<RequestMasterVacation> requestMasterVacations { get; set; }
        public DbSet<RequestDetailsVacation> requestDetailsVacations { get;set; }
        public DbSet<VacationType> vacationTypes { get; set; }

    }
}
