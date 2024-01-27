using FluentValidation.Results;
using System.Net;

namespace App.InterViews.Report.CrossCutting.Helper
{
    public class ErrorResult : ValidationResult
    {
        public HttpStatusCode StatusCode { get; private set; }

        protected ErrorResult(IEnumerable<ValidationFailure> failures, HttpStatusCode httpStatusCode) : base(failures)
        {
            StatusCode = httpStatusCode;
        }

        public static ErrorResult NotFound<TClass>() where TClass : class
        {
            var failures = new List<ValidationFailure>() { new() { ErrorMessage = $"{typeof(TClass).Name} not found" } };
            return new ErrorResult(failures, HttpStatusCode.NotFound);
        }

        public static ErrorResult Exception<TClass>(string messageError) where TClass : class
        {
            var failures = new List<ValidationFailure>() { new() { ErrorMessage = $"{typeof(TClass).Name} found some error : {messageError}" } };
            return new ErrorResult(failures, HttpStatusCode.InternalServerError);
        }

        public static ErrorResult Validation(IEnumerable<ValidationFailure> failures)
        {
            return new ErrorResult(failures, HttpStatusCode.BadRequest);
        }
    }
}
