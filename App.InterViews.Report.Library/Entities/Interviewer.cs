using App.InterViews.Report.CrossCutting.Enums;

namespace App.InterViews.Report.Library.Entities
{
    public class Interviewer : BaseEntity
    {
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Email { get; set; }
        public JobPositionType JobPosition { get; set; }
        public int? Age { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid InterviewId { get; set; }
        public User User { get; set; }
        public Company Company { get; set; }
        public InterView InterView { get; set; }
    }
}
