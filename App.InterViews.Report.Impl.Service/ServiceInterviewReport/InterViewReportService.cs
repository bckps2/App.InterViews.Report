using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;

namespace App.InterViews.Report.Impl.Service.ServiceInterviewReport
{
    public class InterViewReportService : IInterViewReportService
    {
        private readonly IRepositoryCompany _iRepositoryInterCompany;
        private readonly IRepositoryBase<InformationInterView> _iRepositoryBaseInformation;
        private readonly IRepositoryBase<InterView> _iRepositoryInterview;
        public InterViewReportService(IRepositoryCompany iRepositoryInterCompany, IRepositoryBase<InformationInterView> iRepositoryBaseInformation, IRepositoryBase<InterView> iRepositoryInterview)
        {
            _iRepositoryInterCompany = iRepositoryInterCompany;
            _iRepositoryBaseInformation = iRepositoryBaseInformation;
            _iRepositoryInterview = iRepositoryInterview;
        }

        public List<Company> GetAllInterViews()
        {
            var companies = _iRepositoryInterCompany.GetAll();

            foreach (var item in companies)
            {
               
                foreach (var interview in item.InterViews)
                {
                    interview.InformationInterViews.ForEach(c => c.SetListInterViewers());
                }
            }

            return companies;
        }

        public Company? AddInterView(Company company)
        {
            try
            {
                var interview = company.InterViews.FirstOrDefault();
               
                if (interview != null)
                {

                    interview.InformationInterViews.ForEach(c => c.SetNameInterViewers());
                    return _iRepositoryInterCompany.Add(company).Value;
                }

                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public InformationInterView? UpdateInterViewInformation(InformationInterView informationInterView)
        {
            try
            {
                var interView = _iRepositoryInterview.GetById(informationInterView.InterViewIdInterView).Result.Value;
                if(interView != null) 
                {
                    informationInterView.SetNameInterViewers();
                    return _iRepositoryBaseInformation.Update(informationInterView).Value;
                }
                
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public InterView? AddInterViewOfCompany(InterView interView)
        {
            try
            {
                var company = _iRepositoryInterview.GetById(interView.CompanyIdCompany).Result.Value;
                if (company != null)
                {
                    foreach (var item in interView.InformationInterViews)
                    {
                        item.SetNameInterViewers();
                    }
                    return _iRepositoryInterview.Add(interView).Value;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
