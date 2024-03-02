using App.InterViews.Report.CrossCutting.Enums;

namespace App.InterViews.Report.Service.Dtos.Interviewer
{
    public class InterviewerInterviewDto
    {
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Email { get; set; }
        public JobPositionType JobPosition { get; set; }
        public Guid CompanyId { get; set; }
        public int? Age { get; set; }
        public ICollection<Guid> InterviewsId { get; set; }
    }
}
