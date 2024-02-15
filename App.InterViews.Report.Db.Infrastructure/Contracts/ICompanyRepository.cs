using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Library.Entities;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Db.Infrastructure.Contracts;

public interface ICompanyRepository : IRepositoryBase<Company>
{
    Task<Result<IEnumerable<Company>, ErrorResult>> GetAllCompaniesByUserAsync(Guid userId);
}
