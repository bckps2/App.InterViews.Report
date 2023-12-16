using AutoMapper;
using CSharpFunctionalExtensions;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using App.InterViews.Report.CrossCutting.Helper;
using CSharpFunctionalExtensions.ValueTasks;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Implements;

public class CompanyReportService<TEntry> : ICompanyReportService<TEntry>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<TEntry> _iRepositoryBase;

    public CompanyReportService(IRepositoryBase<TEntry> iRepositoryBase, IMapper mapper)
    {
        _mapper = mapper;
        _iRepositoryBase = iRepositoryBase;
    }

    public async Task<Result<CompanyDto, ErrorResult>> GetById(int id)
    {
        var value = await _iRepositoryBase.GetByIdAsync(id);

        return value.Map(val =>
        {
            return _mapper.Map<CompanyDto>(val);
        });
    }

    public Result<IEnumerable<CompanyDto>, ErrorResult> GetAll()
    {
        var companies = _iRepositoryBase.GetAll();

        return companies.Map(value =>
        {
            return _mapper.Map<IEnumerable<CompanyDto>>(value);
        });
    }

    public async Task<Result<CompanyDto, ErrorResult>> Add(CompanyDto dto)
    {
        var company = _mapper.Map<TEntry>(dto);
        var result = await _iRepositoryBase.AddAsync(company);

        return result.Map(val =>
        {
            return _mapper.Map<CompanyDto>(val);
        });
    }

    public async Task<Result<CompanyDto, ErrorResult>> Delete(int id)
    {
        var company = await _iRepositoryBase.GetByIdAsync(id);

        if (company.IsSuccess)
        {
            var response = _iRepositoryBase.Delete(company.Value);

            return response.Map(val =>
            {
                return _mapper.Map<CompanyDto>(val);
            });
        }

        return company.Map(val => _mapper.Map<CompanyDto>(val));
    }
}
