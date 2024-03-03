namespace App.InterViews.Report.Models;

public class UserAccountModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public Guid RoleId { get; set; }
}
