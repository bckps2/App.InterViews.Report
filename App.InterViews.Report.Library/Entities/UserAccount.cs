using App.InterViews.Report.CrossCutting.Enums;

namespace App.InterViews.Report.Library.Entities;

public class UserAccount : BaseEntity
{
    public string Email { get; set; }
    public string Password { get; set; }
    public Guid? RoleId { get; set; }
    public Role? Role { get; set; }
    public virtual UserInfo UserInfo { get; set; }
}
