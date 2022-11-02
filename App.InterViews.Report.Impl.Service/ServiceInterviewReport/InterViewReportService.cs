using AutoMapper;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Library.Extensions;
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

        public List<InterView> GetAllInterViewsByIdProcess(int idProcess)
        {
            var response = GetAllInterViews().Where(c => c.IdProcess == idProcess).ToList();
            return response;
        }

        public List<InterView> GetAllInterViews()
        {
            var response = _iRepositoryInterview.GetAll().ToList();
            response.ForEach(interview => interview.SetNameInterViewers());
            return response;
        }

        public InterView? AddInterview(ServiceInterviewModel interviewModel)
        {
            try
            {
                var interview = _mapper.Map<InterView>(interviewModel);
                interview.SetInterViewersName();
                var response = _iRepositoryInterview.Add(interview).Value;
                response.SetNameInterViewers(); 
                return response;
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

        public InterView? UpdateInterview(ServiceInterviewModel informationModel)
        {
            try
            {
                var interviewDb = _iRepositoryInterview.GetById(informationModel.IdInterview);
                if (interviewDb != null)
                {
                    var interview = _mapper.Map<InterView>(informationModel);
                    interview.SetInterViewersName();
                    interviewDb.InterViewersName = interview.InterViewersName;
                    interviewDb.Email = interview.Email;
                    interviewDb.Observations = interview.Observations;
                    interviewDb.DateInterView = interview.DateInterView;
                    interviewDb.TypeInterView = interview.TypeInterView;
                    var response = _iRepositoryInterview.Update(interviewDb).Value;
                    response.SetNameInterViewers();
                    return response;
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
