namespace App.InterViews.Report.Library.Entities;

public class InterviewInterviewer : BaseEntity
{
    public InterviewInterviewer()
    {
        Id = Guid.NewGuid();
        DateCreated = DateTime.Now;
    }

    public Guid? InterviewId { get; set; }
    public Interview? InterView { get; set; }
    public Guid InterviewerId { get; set; }
    public Interviewer Interviewer { get; set; }
}
