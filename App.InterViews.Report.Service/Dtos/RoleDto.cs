using App.InterViews.Report.CrossCutting.Enums;

namespace App.InterViews.Report.Service.Dtos;

public class RoleDto : BaseDto
{
    public RoleType RoleType { get; set; }
    public string RoleName { get; set; }
}
