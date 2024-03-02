using App.InterViews.Report.CrossCutting.Enums;

namespace App.InterViews.Report.Models.Interviewer;

public class InterviewerUpdateModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surnames { get; set; }
    public string Email { get; set; }
    public int? Age { get; set; }
    public Guid InterviewId { get; set; }
    public JobPositionType JobPosition { get; set; }
}
