using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Library.Entities;

namespace App.InterViews.Report.Contract.Service.ServiceInterviewReport
{
    public interface IProcessReportService
    {
        public List<Process>? GetAll();
        public Process? DeleteProcess(int idInformation);
        public List<Process>? GetAllByIdCompany(int idInterview);
        public Process? AddProcess(ServiceProcessModel informationModel);
    }
}
