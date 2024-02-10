using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Implements;

public class ProcessReportService : BaseReportService<Process, ProcessDto>, IProcessReportService
{
    public ProcessReportService(IMapper mapper, IRepositoryBase<Process> iRepositoryBase) : base(iRepositoryBase, mapper)
    {
    }

    public Result<IEnumerable<ProcessDto>, ErrorResult> GetProcessesByIdCompany(Guid idCompany)
    {
        var companies = _iRepositoryBase.GetEntitiesByFilter(c => c.IdCompany == idCompany);

        return companies.Map(value =>
        {
            return _mapper.Map<IEnumerable<ProcessDto>>(value);
        });
    }
}
