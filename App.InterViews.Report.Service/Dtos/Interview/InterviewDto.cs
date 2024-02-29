using App.InterViews.Report.CrossCutting.Enums;
using App.InterViews.Report.Service.Dtos.Interviewer;
using System.ComponentModel.DataAnnotations;

namespace App.InterViews.Report.Service.Dtos.Interview;

public class InterviewDto : BaseDto
{
    [Required]
    public Guid IdProcess { get; set; }
    [Required]
    public InterviewType TypeInterView { get; set; }
    public DateTime DateInterView { get; set; }
    [Required]
    public string? Observations { get; set; }
}
