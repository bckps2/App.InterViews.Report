namespace App.InterViews.Report.Library.Entities;

public class UserCompany : BaseEntity
{
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
}
