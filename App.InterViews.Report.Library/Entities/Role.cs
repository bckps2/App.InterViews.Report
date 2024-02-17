using App.InterViews.Report.CrossCutting.Enums;

namespace App.InterViews.Report.Library.Entities;

public class Role : BaseEntity
{
    public string RoleName { get; set; }
    public RoleType RoleType { get; set; }
    public List<User> Users { get; set; }
}
