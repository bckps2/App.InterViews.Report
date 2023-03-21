using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace App.InterViews.Report.Service.Dtos;

public class ProcessDto
{
    public string? JobPosition { get; set; }
    public int IdCompany { get; set; }
    public string? ExternalCompany { get; set; }
    [Required]
    public string? RangeSalarial { get; set; }
    [JsonIgnore]
    public DateTime DateCreated { get; } = DateTime.Now;
    public IList<InterviewDto>? Interviews { get; set; }
}
