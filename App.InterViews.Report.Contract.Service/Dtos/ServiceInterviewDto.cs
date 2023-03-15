using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using App.InterViews.Report.CrossCutting.Enums;

namespace App.InterViews.Report.Contract.Service.Dtos;

public class ServiceInterviewDto
{
    [Required]
    public int IdProcess { get; set; }
    public int IdInterview { get; set; }
    [Required]
    public TypeInterview TypeInterView { get; set; }
    [Required]
    public List<string>? NameInterViewers { get; set; }
    public DateTime DateInterView { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Observations { get; set; }
    public DateTime DateCreated { get; } = DateTime.Now;
}
