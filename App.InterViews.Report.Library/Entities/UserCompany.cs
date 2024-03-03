namespace App.InterViews.Report.Library.Entities;

public class UserCompany : BaseEntity
{
    public UserCompany()
    {
        Id = Guid.NewGuid();
        DateCreated = DateTime.UtcNow;
    }

    public Guid UserId { get; set; }
    public UserInfo? User { get; set; }
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
}
