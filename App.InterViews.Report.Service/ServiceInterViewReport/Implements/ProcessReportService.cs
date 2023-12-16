using AutoMapper;
using FluentValidation.Results;
using CSharpFunctionalExtensions;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using App.InterViews.Report.CrossCutting.Helper;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Implements;

public class ProcessReportService<TEntry> : IProcessReportService<TEntry>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<TEntry> _iRepositoryBase;

    public ProcessReportService(IMapper mapper, IRepositoryBase<TEntry> iRepositoryBase)
    {
        _mapper = mapper;
        _iRepositoryBase = iRepositoryBase;
    }

    public async Task<Result<ProcessDto, ErrorResult>> Add(ProcessDto dto)
    {
        var company = _mapper.Map<TEntry>(dto);
        var result = await _iRepositoryBase.AddAsync(company);

        return result.Map(val =>
        {
            return _mapper.Map<ProcessDto>(val);
        });
    }

    public async Task<Result<ProcessDto, ErrorResult>> Delete(int id)
    {
        var processDto = await _iRepositoryBase.GetByIdAsync(id);

        if (processDto.IsSuccess)
        {
            var response = _iRepositoryBase.Delete(processDto.Value);

            return response.Map(val =>
            {
                return _mapper.Map<ProcessDto>(val);
            });
        }

        return processDto.Error;
    }

    public Result<IEnumerable<ProcessDto>, ErrorResult> GetAll()
    {
        var companies = _iRepositoryBase.GetAll();

        return companies.Map(value =>
        {
            return _mapper.Map<IEnumerable<ProcessDto>>(value);
        });
    }

    public Result<IEnumerable<ProcessDto>, ErrorResult> GetProcessesByIdCompany(int idCompany)
    {
        var companies = _iRepositoryBase.GetAll();

        return companies.Map(value =>
        {
            return _mapper.Map<IEnumerable<ProcessDto>>(value).Where(process => process.IdCompany == idCompany);
        });
    }

    public async Task<Result<ProcessDto, ErrorResult>> GetById(int id)
    {
        var value = await _iRepositoryBase.GetByIdAsync(id);

        return value.Map(val =>
        {
            return _mapper.Map<ProcessDto>(val);
        });
    }
}
