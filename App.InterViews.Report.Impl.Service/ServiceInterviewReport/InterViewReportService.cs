using AutoMapper;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Contract.Service.Dtos;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Impl.Service.ServiceInterviewReport
{
    public class InterViewReportService<TEntry, TValidation> : IInterViewReportService<TEntry, TValidation>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<TEntry, TValidation> _iRepositoryInterview;

        public InterViewReportService(IMapper mapper, IRepositoryBase<TEntry, TValidation> iRepositoryInterview)
        {
            _iRepositoryInterview = iRepositoryInterview;
            _mapper = mapper;
        }

        public Task<Result<ServiceInterviewDto, TValidation>> AddInterview(ServiceInterviewDto interviewModel)
        {
            var interview = _mapper.Map<TEntry>(interviewModel);
            var result = _iRepositoryInterview.AddAsync(interview);
            return result.Map(val => _mapper.Map<ServiceInterviewDto>(val));
        }

        //public List<InterView> GetAllInterViewsByIdProcess(int idProcess)
        //{
        //    var response = GetAllInterViews().Where(c => c.IdProcess == idProcess).ToList();
        //    return response;
        //}

        //public InterView? GetInterviewById(int idInterview)
        //{
        //    var response = _iRepositoryInterview.GetById(idInterview);
        //    return response;
        //}

        public Result<List<ServiceInterviewDto>, TValidation> GetAllInterViews()
        {
            return _iRepositoryInterview.GetAll().Map(c => _mapper.Map<List<ServiceInterviewDto>>(c));
        }

        //public async Task<Result<TEntry?, TValidation>> AddInterview(ServiceInterviewDto interviewModel)
        //{
        //    var company = _mapper.Map<InterView>(interviewModel);
        //    return (await _iRepositoryInterview.AddAsync(company)).Value;
        //}

        //public InterView? DeleteInterview(int idInterview)
        //{
        //    var interview = _iRepositoryInterview.GetById(idInterview);
        //    if (interview != null)
        //    {
        //        var response = _iRepositoryInterview.Delete(interview);
        //        return response;
        //    }
        //    return null;
        //}

        //public async Task<TEntry?> UpdateInterview(ServiceInterviewDto informationModel)
        //{
        //    try
        //    {
        //        var interviewDb = await _iRepositoryInterview.GetById(informationModel.IdInterview);
        //        if (interviewDb.IsSuccess)
        //        {
        //            var interview = _mapper.Map<InterView>(informationModel);
        //            interview.SetInterViewersName();
        //            interviewDb.Value.InterViewersName = interview.InterViewersName;
        //            interviewDb.Value.Email = interview.Email;
        //            interviewDb.Value.Observations = interview.Observations;
        //            interviewDb.Value.DateInterView = interview.DateInterView;
        //            interviewDb.Value.TypeInterView = interview.TypeInterView;
        //            var response = _iRepositoryInterview.Update(interviewDb.Value).Value;
        //            response.SetNameInterViewers();
        //            return response;
        //        }
        //        return null;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

    }
}
