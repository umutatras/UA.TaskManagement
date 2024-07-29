using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UA.TaskManagement.Domain.Entities;

namespace UA.TaskManagement.Persistance.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.Property(x => x.Description).IsRequired(true);
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x=>x.AppUserId).IsRequired(true);
        builder.Property(x=>x.State).IsRequired(true);
    }
}
