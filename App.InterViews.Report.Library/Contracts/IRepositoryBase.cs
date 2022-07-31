using Microsoft.AspNetCore.Mvc;

namespace App.InterViews.Report.Library.Contracts
{
    public interface IRepositoryBase<T>
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
        ActionResult<T> Add(T item);
        ActionResult<T> Update(T item);
        T Delete(T item);
    }
}
