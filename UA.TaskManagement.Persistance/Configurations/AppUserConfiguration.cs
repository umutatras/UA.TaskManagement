using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UA.TaskManagement.Domain.Entities;

namespace UA.TaskManagement.Persistance.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Surname).IsRequired(true);
            builder.Property(x => x.Password).IsRequired(true);
            builder.Property(x => x.UserName).IsRequired(true);
            builder.HasIndex(x=>x.UserName).IsUnique(true);
            builder.Property(x => x.UserName).HasMaxLength(200);

            builder.HasMany(x => x.Tasks).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);
            builder.HasMany(x => x.Notifications).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);
            
        }
    }
}
