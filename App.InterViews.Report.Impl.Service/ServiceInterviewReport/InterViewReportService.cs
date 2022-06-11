using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;

namespace App.InterViews.Report.Impl.Service.ServiceInterviewReport
{
    public class InterViewReportService : IInterViewReportService
    {
        private readonly IRepositoryCompany _iRepositoryInterView;
        private readonly IRepositoryBase<InformationInterView> _iRepositoryBaseInformation;

        public InterViewReportService(IRepositoryCompany iRepositoryInterView, IRepositoryBase<InformationInterView> iRepositoryBaseInformation)
        {
            _iRepositoryInterView = iRepositoryInterView;
            _iRepositoryBaseInformation = iRepositoryBaseInformation;
        }

        public List<Company> GetAllInterViews()
        {
            var companies = _iRepositoryInterView.GetAll();

            foreach (var item in companies)
            {
               
                foreach (var interview in item.InterViews)
                {
                    interview.InformationInterViews.ForEach(c => c.SetListInterViewers());
                }
            }

            return companies;
        }

        public bool AddInterView(Company company)
        {
            try
            {
                var interview = company.InterViews.FirstOrDefault();
               
                if (interview != null)
                {

                    interview.InformationInterViews.ForEach(c => c.SetNameInterViewers());
                    var response = _iRepositoryInterView.Add(company);
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
