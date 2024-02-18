using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.Dtos.Company;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Implements;

public class InterviewerService : BaseReportService<Interviewer, InterviewerDto>, IInterviewerService
{
    public InterviewerService(IRepositoryBase<Interviewer> iRepositoryBase, IMapper mapper) : base(iRepositoryBase, mapper)
    {
    }
}
