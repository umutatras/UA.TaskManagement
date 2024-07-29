using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UA.TaskManagement.Domain.Entities;

namespace UA.TaskManagement.Persistance.Configurations;

public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.Property(x=>x.Definition).IsRequired();
        builder.Property(x => x.Definition).HasMaxLength(500);
        builder.HasMany(x=>x.Users).WithOne(x=>x.Role).HasForeignKey(x=>x.AppRoleId);
    }
}
