using App.InterViews.Report.Contract.Service.Dtos;
using App.InterViews.Report.Library.Entities;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Contract.Service.ServiceInterviewReport
{
    public interface IInterViewReportService<TEntry, TValidation>
    {
        List<ServiceInterviewDto> GetAllInterViews();
        //public List<TEntry> GetAllInterViewsByIdProcess(int idCompany);
        //Task<Result<TEntry?, TValidation>> AddInterview(ServiceInterviewDto interviewModel);
        //public InterView? DeleteInterview(int idInterview);
        //public InterView? UpdateInterview(ServiceInterviewModel informationModel);
        //public InterView? GetInterviewById(int idInterview);
        //Task<InterView?> UpdateInterview(ServiceInterviewDto informationModel);
    }
}
