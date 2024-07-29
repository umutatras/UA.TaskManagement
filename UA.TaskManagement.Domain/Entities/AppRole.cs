namespace UA.TaskManagement.Domain.Entities;

public class AppRole: BaseEntity
{
    public string Definition { get; set; } = null!;

    #region Navigation Properties
    public List<AppUser>? Users { get; set; }

    #endregion
}
