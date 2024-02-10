namespace App.InterViews.Report.Library.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Surnames { get; set; }
    public string City { get; set; }
    public string Email { get; set; }
    public ICollection<UserCompany> UserCompanies { get; set; }
}
