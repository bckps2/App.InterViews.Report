using FluentValidation.Results;
using System.Net;

namespace App.InterViews.Report.CrossCutting.Helper
{
    public class ErrorResult : ValidationResult
    {
        public HttpStatusCode StatusCode { get; private set; }

        public ErrorResult() { }

        protected ErrorResult(IEnumerable<ValidationFailure> failures, HttpStatusCode httpStatusCode) : base(failures)
        {
            StatusCode = httpStatusCode;
        }
    }
}
