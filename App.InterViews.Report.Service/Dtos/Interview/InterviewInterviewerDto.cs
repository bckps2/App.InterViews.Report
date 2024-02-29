using App.InterViews.Report.CrossCutting.Enums;
using App.InterViews.Report.Service.Dtos.Interviewer;
using System.ComponentModel.DataAnnotations;

namespace App.InterViews.Report.Service.Dtos.Interview;

public class InterviewInterviewerDto
{
    [Required]
    public Guid IdProcess { get; set; }
    [Required]
    public InterviewType TypeInterView { get; set; }
    public DateTime DateInterView { get; set; }
    [Required]
    public string? Observations { get; set; }
    public ICollection<InterviewerDto>? Interviewers { get; set; }
}
