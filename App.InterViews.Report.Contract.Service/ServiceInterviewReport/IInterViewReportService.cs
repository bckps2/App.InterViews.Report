using App.InterViews.Report.Library.Entities;

namespace App.InterViews.Report.Contract.Service.ServiceInterviewReport
{
    public interface IInterViewReportService
    {
        List<InterView> GetAllInterViews();
        bool AddInterView(InterView interView);
        bool UpdateInterViewInformation(InformationInterView informationInterView);
    }
}
