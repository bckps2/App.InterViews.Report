using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Library.Entities;

namespace App.InterViews.Report.Contract.Service.ServiceInterviewReport
{
    public interface IInterViewReportService
    {
        public List<InterView> GetAllInterViews();
        public InterView? AddInterview(ServiceInterviewModel interviewModel);
        public InterView? DeleteInterview(int idInterview);
    }
}
