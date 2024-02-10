using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace App.InterViews.Report.Service.Dtos;

public class ProcessDto : BaseDto
{
    public string? JobPosition { get; set; }
    public Guid IdCompany { get; set; }
    public string? ExternalCompany { get; set; }
    [Required]
    public string? RangeSalarial { get; set; }
    [JsonIgnore]
    public DateTime DateCreated { get; set; }
    public IList<InterviewDto>? Interviews { get; set; }
}
