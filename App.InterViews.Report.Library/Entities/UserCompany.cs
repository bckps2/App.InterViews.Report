namespace App.InterViews.Report.Library.Entities;

public class UserCompany : BaseEntity
{
    public override Guid Id => Guid.NewGuid();
    public override DateTime DateCreated => DateTime.UtcNow;
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
}
