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
        public InterViewReportService(IMapper mapper, IRepositoryCompany iRepositoryInterCompany, IRepositoryBase<InformationInterView> iRepositoryBaseInformation, IRepositoryBase<InterView> iRepositoryInterview)
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

            return companies.ToList();
        }

        public Company? AddInterView(ServiceCompanyModel companyModel)
        {
            try
            {
                var company = new Company();
                var interview = _mapper.Map<InterView>(companyModel.Interview);
                var information = _mapper.Map<InformationInterView>(companyModel.Interview.InformationInterview);
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

        public InformationInterView? AddInterViewInformation(ServiceInformationModel informationModel)
        {
            try
            {
                var interView = _iRepositoryInterview.GetById(informationModel.InterViewIdInterView);
                if (interView != null)
                {
                    var information = _mapper.Map<InformationInterView>(informationModel);
                    information.SetNameInterViewers();
                    return _iRepositoryBaseInformation.Add(information).Value;
                }
                return null;
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
                var informationDb = _iRepositoryBaseInformation.GetById(informationModel.IdInformation);
                if (informationDb != null)
                {
                    var information = _mapper.Map<InformationInterView>(informationModel);
                    information.SetNameInterViewers();
                    informationDb.InterViewersName = information.InterViewersName;
                    informationDb.Email = information.Email;
                    informationDb.Observations = information.Observations;
                    informationDb.DateInterView = information.DateInterView;
                    informationDb.TypeInterView = information.TypeInterView;
                    var response = _iRepositoryBaseInformation.Update(informationDb).Value;
                    response.SetListInterViewers();
                    return response;
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
                var company = _iRepositoryInterCompany.GetById(interviewModel.CompanyIdCompany);
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

        public InformationInterView? DeleteInformation(int idInformation)
        {
            var information = _iRepositoryBaseInformation.GetById(idInformation);
            if (information != null)
            {
                var response = _iRepositoryBaseInformation.Delete(information);
                return response;
            }

            return null;
        }

        public InterView? DeleteInterview(int idInterview) 
        {
            var interview = _iRepositoryInterview.GetById(idInterview);
            if (interview != null)
            {
                var response = _iRepositoryInterview.Delete(interview);
                return response;
            }
            return null;
        }

        public Company? DeleteCompany(int idcompany)
        {
            var company = _iRepositoryInterCompany.GetById(idcompany);
            if (company != null)
            {
                var response = _iRepositoryInterCompany.Delete(company);
                return response;
            }
            return null;
        }
    }
}
