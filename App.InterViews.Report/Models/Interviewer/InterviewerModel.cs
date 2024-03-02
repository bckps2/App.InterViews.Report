using App.InterViews.Report.CrossCutting.Enums;
using App.InterViews.Report.Models.Interview;

namespace App.InterViews.Report.Models.Interviewer
{
    public class InterviewerModel
    {
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public Guid CompanyId { get; set; }
        public ICollection<Guid> InterviewsId { get; set; }
        public JobPositionType JobPosition { get; set; }
    }
}
