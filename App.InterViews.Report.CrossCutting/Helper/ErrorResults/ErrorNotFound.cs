using FluentValidation.Results;
using System.Net;

namespace App.InterViews.Report.CrossCutting.Helper.ErrorResults
{
    public class ErrorNotFound : ErrorResult
    {
        public ErrorNotFound(IEnumerable<ValidationFailure> failures, HttpStatusCode httpStatusCode) : base(failures, httpStatusCode)
        { }

        public static ErrorNotFound NotFound<TClass>()
        {
            var failures = new List<ValidationFailure>() { new() { ErrorMessage = $"{typeof(TClass).Name} not found" } };
            return new ErrorNotFound(failures, HttpStatusCode.NotFound);
        }
    }
}
