using FluentValidation.Results;
using System.Net;

namespace App.InterViews.Report.CrossCutting.Helper.ErrorResults
{
    public class ErrorException : ErrorResult
    {
        public ErrorException(IEnumerable<ValidationFailure> failures, HttpStatusCode httpStatusCode) : base(failures, httpStatusCode)
        {
                
        }

        public static ErrorException Exception<TClass>(string messageError)
        {
            var failures = new List<ValidationFailure>() { new() { ErrorMessage = $"{typeof(TClass).Name} found some error : {messageError}" } };
            return new ErrorException(failures, HttpStatusCode.NotFound);
        }
    }
}
