using App.InterViews.Report.CrossCutting.Enums;

namespace App.InterViews.Report.Service.Dtos;

public class UserAccountDto : BaseDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public Guid RoleId { get; set; }
}
