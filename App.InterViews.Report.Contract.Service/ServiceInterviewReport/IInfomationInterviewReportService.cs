using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InterViews.Report.Contract.Service.ServiceInterviewReport
{
    public interface IInfomationInterviewReportService
    {
        public List<InformationInterView>? GetAll();
        public InformationInterView? DeleteInformation(int idInformation);
        public List<InformationInterView>? GetAllByIdInterview(int idInterview);
        public InformationInterView? AddInterViewInformation(ServiceInformationModel informationModel);
        public InformationInterView? UpdateInterViewInformation(ServiceInformationModel informationModel);
    }
}
