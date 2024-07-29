using Microsoft.EntityFrameworkCore;
using UA.TaskManagement.Domain.Entities;

namespace UA.TaskManagement.Persistance.Context;

public class TaskManagementContext : DbContext
{
    public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options)
    {
    }

    public DbSet<AppRole> Roles { get; set; }
    public DbSet<AppTask> Tasks { get; set; }
    public DbSet<Priority> Priorities { get; set; }
    public DbSet<TaskReport> TaskReports { get; set; }
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Notification> Notifications { get; set; }
}
