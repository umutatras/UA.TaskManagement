namespace UA.TaskManagement.Domain.Entities;

public class AppTask: BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; }=null!;
    public int AppUserId { get; set; }
    public int PriorityId { get; set; }
    public bool State { get; set; }

    #region Navigation Properties
    public Priority? Priority { get; set; }
    public AppUser? AppUser { get; set; }
    public List<TaskReport>? TaskReports { get; set; }
    #endregion

}
