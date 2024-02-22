using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMP.Models;

namespace UMP.Configure
{
    public class DoctorConfigure : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable(nameof(Doctor));
            builder.HasKey(x => x.Id);  
            builder.Property(x => x.Name).HasMaxLength(256);
            builder.Property(x => x.Phone).HasMaxLength(256);
            builder.Property(x => x.Email).HasMaxLength(256);
            builder.Property(x => x.Address).HasMaxLength(256);
        }
    }
}
