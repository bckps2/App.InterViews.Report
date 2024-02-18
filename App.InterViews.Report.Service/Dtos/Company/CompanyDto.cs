using System.Text.Json.Serialization;

namespace App.InterViews.Report.Service.Dtos.Company;

public class CompanyDto : BaseDto
{
    public string? CompanyName { get; set; }
    public DateTime DateCreated { get; set; }
    public IList<ProcessDto>? Process { get; set; }

    [JsonIgnore]
    public Guid? UserId { get; set; }
}
