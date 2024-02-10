using System.Text.Json.Serialization;

namespace App.InterViews.Report.Service.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surnames { get; set; }
    public string City { get; set; }
    public string Email { get; set; }
    public List<CompanyDto> Companies { get; set; }

    [JsonIgnore]
    public Guid CompanyId { get; set; }
}
