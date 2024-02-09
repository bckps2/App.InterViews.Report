namespace App.InterViews.Report.Library.Entities;

public class UserCompany
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }
}
