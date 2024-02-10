namespace App.InterViews.Report.Library.Entities;

public class Company : BaseEntity
{
    public string? CompanyName { get; set; }
    public ICollection<UserCompany> UserCompanies { get; set; } = new List<UserCompany>();
    public virtual ICollection<Process>? Process { get; set; }
}
