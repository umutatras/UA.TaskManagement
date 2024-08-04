using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UA.TaskManagement.Domain.Entities;

namespace UA.TaskManagement.Persistance.Configurations;

public class AppTaskConfiguration : IEntityTypeConfiguration<AppTask>
{
    public void Configure(EntityTypeBuilder<AppTask> builder)
    {
        builder.Property(x => x.PriorityId).IsRequired(true);
        builder.Property(x=>x.AppUserId).IsRequired(false);
        builder.Property(x=>x.Description).IsRequired(true);
        builder.Property(x=>x.Title).IsRequired(true);
        builder.Property(x => x.Title).HasMaxLength(250);

        builder.HasMany(x => x.TaskReports).WithOne(x => x.AppTask).HasForeignKey(x => x.AppTaskId);
    }
}
