using App.InterViews.Report.Library.Entities;

namespace App.InterViews.Report.Contract.Service.ServiceInterviewReport
{
    public interface IInterViewReportService
    {
        List<Company> GetAllInterViews();
        bool AddInterView(Company interView);
        bool UpdateInterViewInformation(InformationInterView informationInterView);
    }
}
