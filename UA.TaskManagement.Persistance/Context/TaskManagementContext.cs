using Microsoft.EntityFrameworkCore;
using UA.TaskManagement.Domain.Entities;
using UA.TaskManagement.Persistance.Configurations;

namespace UA.TaskManagement.Persistance.Context;

public class TaskManagementContext : DbContext
{
    public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AppTaskConfiguration());
        modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        modelBuilder.ApplyConfiguration(new TaskReportConfiguration());
        modelBuilder.ApplyConfiguration(new NotificationConfiguration());
        modelBuilder.ApplyConfiguration(new PriorityConfiguration());
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<AppRole> Roles { get; set; }
    public DbSet<AppTask> Tasks { get; set; }
    public DbSet<Priority> Priorities { get; set; }
    public DbSet<TaskReport> TaskReports { get; set; }
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Notification> Notifications { get; set; }
}
