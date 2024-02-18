using App.InterViews.Report.CrossCutting.Enums;

namespace App.InterViews.Report.Library.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Surnames { get; set; }
    public string? City { get; set; }
    public string Email { get; set; }
    public string? IdentificationDocumentNumber { get; set; }
    public DocumentType? DocumentType { get; set; }
    public Guid? RoleId { get; set; }
    public Role? Role { get; set; }
    public ICollection<Interviewer>? Interviewers {get;set;}
    public ICollection<UserCompany> UserCompanies { get; set; } = new List<UserCompany>();
}
