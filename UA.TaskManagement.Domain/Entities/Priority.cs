namespace UA.TaskManagement.Domain.Entities;

public class Priority: BaseEntity
{
    public string Definition { get; set; } = null!;

    #region NavigationProperties
    public List<AppTask>? Tasks { get; set; }
    #endregion
}
