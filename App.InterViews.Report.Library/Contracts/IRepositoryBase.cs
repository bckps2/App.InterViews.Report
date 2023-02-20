using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace App.InterViews.Report.Library.Contracts
{
    public interface IRepositoryBase<TEntry, TDefaultValue>
    {
        Task<Result<TEntry, TDefaultValue>> GetById(int id);
        Result<IEnumerable<TEntry>, TDefaultValue> GetAll();
        Task<Result<TEntry, TDefaultValue>> AddAsync(TEntry item);
        ActionResult<TEntry> Update(TEntry item);
        TEntry Delete(TEntry item);
    }
}
