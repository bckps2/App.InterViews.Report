using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace App.InterViews.Report.Library.Contracts
{
    public interface IRepositoryBase<T, TDefaultValue>
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
        Task<Result<T, TDefaultValue>> AddAsync(T item);
        ActionResult<T> Update(T item);
        T Delete(T item);
    }
}
