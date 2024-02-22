using Microsoft.EntityFrameworkCore;
using UMP.ViewModel;

namespace UMP.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        public DbSet<UMP.ViewModel.DoctorVm> DoctorVm { get; set; } = default!;
    }
}
