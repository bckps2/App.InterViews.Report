using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using AutoMapper;
using App.InterViews.Report.Contract.Service.Models;

namespace App.InterViews.Report.Impl.Service.ServiceInterviewReport
{
    public class InterViewReportService : IInterViewReportService
    {
        private readonly IRepositoryCompany _iRepositoryInterCompany;
        private readonly IRepositoryBase<InformationInterView> _iRepositoryBaseInformation;
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<InterView> _iRepositoryInterview;
        public InterViewReportService(IMapper mapper , IRepositoryCompany iRepositoryInterCompany, IRepositoryBase<InformationInterView> iRepositoryBaseInformation, IRepositoryBase<InterView> iRepositoryInterview)
        {
            _iRepositoryInterCompany = iRepositoryInterCompany;
            _iRepositoryBaseInformation = iRepositoryBaseInformation;
            _iRepositoryInterview = iRepositoryInterview;
            _mapper = mapper;
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

        public Company? AddInterView(ServiceCompanyModel companyModel)
        {
            try
            {
                var company = new Company();
                var interview = _mapper.Map<InterView>(companyModel.Interview);
                var information = _mapper.Map<InformationInterView> (companyModel.Interview.InformationInterview);
                interview.InformationInterViews = new List<InformationInterView> { information };

                company.CompanyName = companyModel.CompanyName;
                company.DateCreated = companyModel.DateCreated;
                interview.InformationInterViews.ForEach(c => c.SetNameInterViewers());
                company.InterViews = new List<InterView> { interview };
                return _iRepositoryInterCompany.Add(company).Value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public InformationInterView? UpdateInterViewInformation(ServiceInformationModel informationModel)
        {
            try
            {
                var interView = _iRepositoryInterview.GetById(informationModel.InterViewIdInterView).Result.Value;
                if (interView != null)
                {
                    var information = _mapper.Map<InformationInterView>(informationModel);
                    information.SetNameInterViewers();
                    return _iRepositoryBaseInformation.Update(information).Value;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public InterView? AddInterViewOfCompany(ServiceInterviewModel interviewModel)
        {
            try
            {
                var company = _iRepositoryInterCompany.GetById(interviewModel.CompanyIdCompany).Result.Value;
                if (company != null)
                {
                    var interview = _mapper.Map<InterView>(interviewModel);
                    var information = _mapper.Map<InformationInterView>(interviewModel.InformationInterview);
                    interview.InformationInterViews = new List<InformationInterView> { information };
                    interview.InformationInterViews.ForEach(c => c.SetNameInterViewers());
                    return _iRepositoryInterview.Add(interview).Value;
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
