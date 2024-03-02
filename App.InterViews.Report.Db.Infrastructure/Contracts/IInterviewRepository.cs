using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Library.Entities;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Db.Infrastructure.Contracts;

public interface IInterviewRepository : IRepositoryBase<InterView>
{
    Task<Result<IEnumerable<InterView>, ErrorResult>> GetAllByIdProcessAsync(Guid processId);
}
