using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Library.Entities;

namespace App.InterViews.Report.Contract.Service.ServiceInterviewReport
{
    public interface IInterViewReportService
    {
        List<Company> GetAllInterViews();
        Company? AddInterView(ServiceCompanyModel companyModel);
        InformationInterView? UpdateInterViewInformation(ServiceInformationModel informationModel);
        InterView? AddInterViewOfCompany(ServiceInterviewModel interviewModel);
    }
}
