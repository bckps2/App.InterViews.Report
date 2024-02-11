using App.InterViews.Report.CrossCutting.Enums;

namespace App.InterViews.Report.Models;

public class UserModel
{
    public string Name { get; set; }
    public string Surnames { get; set; }
    public string City { get; set; }
    public string Email { get; set; }
    public DocumentType? DocumentType { get; set; }
    public string? IdentificationDocumentNumber { get; set; }
    public Guid? CompanyId { get; set; }
}
