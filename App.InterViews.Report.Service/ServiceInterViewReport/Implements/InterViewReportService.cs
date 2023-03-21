using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using CSharpFunctionalExtensions;
using FluentValidation.Results;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Implements;

public class InterViewReportService<TEntry> : IInterViewReportService<TEntry> where TEntry : class
{
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<TEntry> _iRepositoryBase;

    public InterViewReportService(IMapper mapper, IRepositoryBase<TEntry> iRepositoryBase)
    {
        _mapper = mapper;
        _iRepositoryBase = iRepositoryBase;
    }

    public async Task<Result<InterviewDto, ValidationResult>> Add(InterviewDto dto)
    {
        var interview = _mapper.Map<TEntry>(dto);
        var result = await _iRepositoryBase.AddAsync(interview);

        return result.Map(val =>
        {
            return _mapper.Map<InterviewDto>(val);
        });
    }

    public async Task<Result<InterviewDto, ValidationResult>> Delete(int id)
    {
        var company = await _iRepositoryBase.GetByIdAsync(id);

        if (company.IsSuccess)
        {
            var response = _iRepositoryBase.Delete(company.Value);

            return response.Map(val =>
            {
                return _mapper.Map<InterviewDto>(val);
            });
        }

        return company.Error;
    }

    public Result<IEnumerable<InterviewDto>, ValidationResult> GetAll()
    {
        var companies = _iRepositoryBase.GetAll();

        return companies.Map(value =>
        {
            return _mapper.Map<IEnumerable<InterviewDto>>(value);
        });
    }

    public async Task<Result<InterviewDto, ValidationResult>> GetById(int id)
    {
        var value = await _iRepositoryBase.GetByIdAsync(id);

        return value.Map(val =>
        {
            return _mapper.Map<InterviewDto>(val);
        });
    }

    public async Task<Result<InterviewDto, ValidationResult>> Update(InterviewDto dto)
    {
        var value = await _iRepositoryBase.GetByIdAsync(dto.IdInterview);
        
        if (value.IsSuccess)
        {
            var interview = _mapper.Map<InterView>(dto) as TEntry;
            var response = _iRepositoryBase.Update(interview!);
            
            return response.Map(val =>
            {
                return _mapper.Map<InterviewDto>(val);
            });
        }

        return value.Error;
    }

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
