using App.InterViews.Report.CrossCutting.Enums;
using System.Text.Json.Serialization;

namespace App.InterViews.Report.Service.Dtos.User;

public class UserDto : BaseDto
{
    public string Name { get; set; }
    public string Surnames { get; set; }
    public string City { get; set; }
    public string Email { get; set; }
    public DocumentType? DocumentType { get; set; }
    public string? IdentificationDocumentNumber { get; set; }
    public RoleDto? Role { get; set; }

    [JsonIgnore]
    public Guid? CompanyId { get; set; }
}
