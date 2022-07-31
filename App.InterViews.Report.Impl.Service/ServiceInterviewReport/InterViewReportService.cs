using AutoMapper;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;

namespace App.InterViews.Report.Impl.Service.ServiceInterviewReport
{
    public class InterViewReportService : IInterViewReportService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<InterView> _iRepositoryInterview;
        public InterViewReportService(IMapper mapper, IRepositoryBase<InterView> iRepositoryInterview)
        {
            _iRepositoryInterview = iRepositoryInterview;
            _mapper = mapper;
        }

        public List<InterView> GetAllInterViewsByIdCompany(int idCompany)
        {
            var interviews = _iRepositoryInterview.GetAll().Where(c => c.CompanyIdCompany == idCompany);
            foreach (var interview in interviews)
            {
                interview.InformationInterViews.ForEach(c => c.SetListInterViewers());
            }
            return interviews.ToList();
        }

        public List<InterView> GetAllInterViews()
        {
            return _iRepositoryInterview.GetAll().ToList();
        }

        public InterView? AddInterview(ServiceInterviewModel interviewModel)
        {
            try
            {
                var interview = _mapper.Map<InterView>(interviewModel);
                return _iRepositoryInterview.Add(interview).Value;
            }
            catch (Exception)
            {
                return null;
            }
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
    }
}
