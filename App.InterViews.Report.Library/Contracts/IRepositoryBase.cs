using Microsoft.AspNetCore.Mvc;

namespace App.InterViews.Report.Library.Contracts
{
    public interface IRepositoryBase<T>
    {
        Task<ActionResult<T?>> GetById(int id);
        Task<ActionResult<IEnumerable<T>>> GetAll();
        ActionResult<T> Add(T item);
        ActionResult<T> Update(T item);
    }
}
