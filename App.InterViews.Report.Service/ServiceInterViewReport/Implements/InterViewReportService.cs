using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Implements;

public class InterViewReportService : BaseReportService<InterView, InterviewDto>, IInterViewReportService
{
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<InterView> _iRepositoryBase;

    public InterViewReportService(IMapper mapper, IRepositoryBase<InterView> iRepositoryBase) : base(iRepositoryBase, mapper)
    {
        _mapper = mapper;
        _iRepositoryBase = iRepositoryBase;
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
}
