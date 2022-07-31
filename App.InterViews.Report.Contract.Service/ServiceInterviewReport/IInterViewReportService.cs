using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Library.Entities;

namespace App.InterViews.Report.Contract.Service.ServiceInterviewReport
{
    public interface IInterViewReportService
    {
        List<Company> GetAllInterViews();
        Company? AddInterView(ServiceCompanyModel companyModel);
        InformationInterView? AddInterViewInformation(ServiceInformationModel informationModel);
        InterView? AddInterViewOfCompany(ServiceInterviewModel interviewModel);
        InformationInterView? DeleteInformation(int idInformation);
        InterView? DeleteInterview(int idInterview);
        InformationInterView? UpdateInterViewInformation(ServiceInformationModel informationModel);
        Company? DeleteCompany(int idcompany);
    }
}
