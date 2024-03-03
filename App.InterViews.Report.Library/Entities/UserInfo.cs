using App.InterViews.Report.CrossCutting.Enums;

namespace App.InterViews.Report.Library.Entities;

public class UserInfo : BaseEntity
{
    public string Name { get; set; }
    public string Surnames { get; set; }
    public string? City { get; set; }
    public Guid UserAccountId { get; set; }
    public UserAccount UserAccount { get; set; }
    public DocumentType? DocumentType { get; set; }
    public string? IdentificationDocumentNumber { get; set; }
    public ICollection<UserCompany> UserCompanies { get; set; } = new List<UserCompany>();
}
