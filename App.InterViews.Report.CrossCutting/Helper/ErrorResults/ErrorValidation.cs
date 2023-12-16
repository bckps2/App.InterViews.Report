using FluentValidation.Results;
using System.Net;

namespace App.InterViews.Report.CrossCutting.Helper.ErrorResults
{
    public class ErrorValidation : ErrorResult
    {
        public ErrorValidation(IEnumerable<ValidationFailure> failures, HttpStatusCode httpStatusCode) : base(failures, httpStatusCode)
        { }

        public static ErrorValidation Validation(IEnumerable<ValidationFailure> failures) 
        {
            return new ErrorValidation(failures, HttpStatusCode.BadRequest);
        }
    }
}
