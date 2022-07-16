using App.InterViews.Report.Library.Entities;

namespace App.InterViews.Report.Contract.Service.ServiceInterviewReport
{
    public interface IInterViewReportService
    {
        List<Company> GetAllInterViews();
        Company? AddInterView(Company company);
        InformationInterView? UpdateInterViewInformation(InformationInterView informationInterView);
        InterView? AddInterViewOfCompany(InterView interView);
    }
}
