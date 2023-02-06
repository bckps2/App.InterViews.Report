using AutoMapper;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Library.Extensions;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using FluentValidation.Results;
using CSharpFunctionalExtensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace App.InterViews.Report.Impl.Service.ServiceInterviewReport
{
    public class InterViewReportService<TValidation> : IInterViewReportService<TValidation>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<InterView, ValidationResult> _iRepositoryInterview;
        public InterViewReportService(IMapper mapper, IRepositoryBase<InterView,ValidationResult> iRepositoryInterview)
        {
            _iRepositoryInterview = iRepositoryInterview;
            _mapper = mapper;
        }

        public List<InterView> GetAllInterViewsByIdProcess(int idProcess)
        {
            var response = GetAllInterViews().Where(c => c.IdProcess == idProcess).ToList();
            return response;
        }

        public InterView? GetInterviewById(int idInterview)
        {
            var response = _iRepositoryInterview.GetById(idInterview);
            return response;
        }

        public List<InterView> GetAllInterViews()
        {
            var response = _iRepositoryInterview.GetAll().ToList();
            response.ForEach(interview => interview.SetNameInterViewers());
            return response;
        }

        public async Task<Result<InterView?, TValidation>> AddInterview(ServiceInterviewModel interviewModel)
        {
            var company = _mapper.Map<InterView>(interviewModel);
            return (await _iRepositoryInterview.AddAsync(company)).Value;
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
