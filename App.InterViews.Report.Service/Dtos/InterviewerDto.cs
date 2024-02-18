using App.InterViews.Report.CrossCutting.Enums;

namespace App.InterViews.Report.Service.Dtos
{
    public class InterviewerDto : BaseDto
    {
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Email { get; set; }
        public JobPositionType JobPosition { get; set; }
        public Guid InterviewId { get; set; }
        public ICollection<InterviewDto> Interviews { get; set; }
    }
}
