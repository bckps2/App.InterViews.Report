using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;

namespace App.InterViews.Report.Impl.Service.ServiceInterviewReport
{
    public class InterViewReportService : IInterViewReportService
    {
        private readonly IRepositoryInterView _iRepositoryInterView;
        private readonly IRepositoryBase<InformationInterView> _iRepositoryBaseInformation;

        public InterViewReportService(IRepositoryInterView iRepositoryInterView, IRepositoryBase<InformationInterView> iRepositoryBaseInformation)
        {
            _iRepositoryInterView = iRepositoryInterView;
            _iRepositoryBaseInformation = iRepositoryBaseInformation;
        }

        public List<InterView> GetAllInterViews()
        {
            return _iRepositoryInterView.GetAll();
        }

        public bool AddInterView(InterView interView)
        {
            try
            {
                var informationInterView = interView.InformationInterViews.FirstOrDefault();
               
                if (informationInterView != null)
                {
                    informationInterView.SetNameInterViewers();
                    var response = _iRepositoryInterView.Add(interView);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateInterViewInformation(InformationInterView informationInterView)
        {
            try
            {
                var interView = _iRepositoryInterView.GetById(informationInterView.InterViewIdInterView).Result.Value;
                if(interView != null) 
                {
                    informationInterView.SetNameInterViewers();
                    _iRepositoryBaseInformation.Update(informationInterView);
                    return true;
                }
                
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
