namespace UA.TaskManagement.Domain.Entities;

public class TaskReport: BaseEntity
{
    public string Definition { get; set; } = null!;
    public string Detail { get; set; } = null!;
    public int AppTaskId { get; set; }

    #region NavigationProperties

    public AppTask? AppTask { get; set; }
    #endregion
}
