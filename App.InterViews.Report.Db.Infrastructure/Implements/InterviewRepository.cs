using App.InterViews.Report.Db.Infrastructure.Context;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;

namespace App.InterViews.Report.Db.Infrastructure.Implements;

public class InterviewRepository : RepositoryBase<InterView>, IInterviewRepository
{
    public InterviewRepository(DbDataContext context) : base(context)
    {
    }
}
