using App.InterViews.Report.CrossCutting.Enums;
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
    [Required]
    public List<string>? NameInterViewers { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateInterView { get; set; }
    [Required]
    public string? Email { get; set; }
    public string? Observations { get; set; }
}