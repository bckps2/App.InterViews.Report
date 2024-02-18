using App.InterViews.Report.CrossCutting.Enums;
using App.InterViews.Report.Models.Interviewer;
using System.ComponentModel.DataAnnotations;

namespace App.InterViews.Report.Models;

public class InterviewModel
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public Guid IdProcess { get; set; }
    
    [Required]
    public InterviewType TypeInterView { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateInterView { get; set; }
    
    public string? Observations { get; set; }
    public ICollection<InterviewerModel>? Interviewers { get; set; }
}