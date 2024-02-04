using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Implements;

public class InterViewReportService : IInterViewReportService
{
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<InterView> _iRepositoryBase;

    public InterViewReportService(IMapper mapper, IRepositoryBase<InterView> iRepositoryBase)
    {
        _mapper = mapper;
        _iRepositoryBase = iRepositoryBase;
    }

    public async Task<Result<InterviewDto, ErrorResult>> Add(InterviewDto dto)
    {
        var interview = _mapper.Map<InterView>(dto);
        var result = await _iRepositoryBase.AddAsync(interview);

        return result.Map(val =>
        {
            return _mapper.Map<InterviewDto>(val);
        });
    }

    public async Task<Result<InterviewDto, ErrorResult>> Delete(Guid id)
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

    public Result<IEnumerable<InterviewDto>, ErrorResult> GetAll()
    {
        var companies = _iRepositoryBase.GetAll();

        return companies.Map(value =>
        {
            return _mapper.Map<IEnumerable<InterviewDto>>(value);
        });
    }

    public Result<IEnumerable<InterviewDto>, ErrorResult> GetAllByIdProcess(Guid idProcess)
    {
        var interviews = _iRepositoryBase.GetEntitiesByFilter(interview => interview.IdProcess == idProcess);

        if (interviews.IsFailure)
            return interviews.Error;

        return interviews.Map(value =>
        {
            return _mapper.Map<IEnumerable<InterviewDto>>(value);
        });
    }

    public async Task<Result<InterviewDto, ErrorResult>> GetById(Guid id)
    {
        var value = await _iRepositoryBase.GetByIdAsync(id);

        return value.Map(val =>
        {
            return _mapper.Map<InterviewDto>(val);
        });
    }

    public async Task<Result<InterviewDto, ErrorResult>> Update(InterviewDto dto)
    {
        var value = await _iRepositoryBase.GetByIdAsync(dto.Id);

        if (value.IsSuccess)
        {
            var interview = _mapper.Map<InterView>(dto);
            var response = _iRepositoryBase.Update(interview);

            return response.Map(val =>
            {
                return _mapper.Map<InterviewDto>(val);
            });
        }

        return value.Error;
    }
}
