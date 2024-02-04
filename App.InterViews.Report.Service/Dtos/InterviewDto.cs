using App.InterViews.Report.CrossCutting.Enums;
using System.ComponentModel.DataAnnotations;

namespace App.InterViews.Report.Service.Dtos;

public class InterviewDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public InterviewType TypeInterView { get; set; }
    [Required]
    public List<string>? NameInterViewers { get; set; }
    public DateTime DateInterView { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Observations { get; set; }
    public DateTime DateCreated { get; set; }
}
