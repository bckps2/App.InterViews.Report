using App.InterViews.Report.CrossCutting.Enums;

namespace App.InterViews.Report.Library.Entities
{
    public class Interview : BaseEntity
    {
        public DateTime DateInterView { get; set; }
        public string? Observations { get; set; }
        public InterviewType TypeInterView { get; set; }
        public Guid ProcessId { get; set; }
        public Process? Process { get; set; }
        public ICollection<InterviewInterviewer> InterviewInterviewers { get; set; }
    }
}
