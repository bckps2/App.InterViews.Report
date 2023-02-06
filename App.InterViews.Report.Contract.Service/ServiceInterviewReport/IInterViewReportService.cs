using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Library.Entities;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Contract.Service.ServiceInterviewReport
{
    public interface IInterViewReportService<TResultValidation>
    {
        public List<InterView> GetAllInterViews();
        public List<InterView> GetAllInterViewsByIdProcess(int idCompany);
        Task<Result<InterView?, TResultValidation>> AddInterview(ServiceInterviewModel interviewModel);
        public InterView? DeleteInterview(int idInterview);
        public InterView? UpdateInterview(ServiceInterviewModel informationModel);
        public InterView? GetInterviewById(int idInterview);
    }
}
