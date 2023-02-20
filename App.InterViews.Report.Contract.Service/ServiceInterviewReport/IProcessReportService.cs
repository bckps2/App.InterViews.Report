using App.InterViews.Report.Contract.Service.Dtos;
using App.InterViews.Report.Library.Entities;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Contract.Service.ServiceInterviewReport
{
    public interface IProcessReportService<TResultValidation>
    {
        //public List<Process>? GetAll();
        List<Process>? GetAllWithInterviews();
        //public Process? DeleteProcess(int idInformation);
        public List<Process>? GetAllByIdCompany(int idInterview);
        Task<Result<Process?, TResultValidation>> AddProcess(ServiceProcessDto informationModel);
    }
}
