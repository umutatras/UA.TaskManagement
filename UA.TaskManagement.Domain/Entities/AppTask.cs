namespace UA.TaskManagement.Domain.Entities;

public class AppTask: BaseEntity
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int AppUserId { get; set; }
    public int PriorityId { get; set; }
    public bool State { get; set; }
}
