using CSharpFunctionalExtensions;
using FluentValidation.Results;

namespace App.InterViews.Report.CrossCutting.Helper
{
    public static class ErrorResult
    {
        public static ValidationResult NotFound<T>()
        {
            var error = new ValidationResult();
            error.Errors.Add(new ValidationFailure() { ErrorMessage = $"{typeof(T).Name} not found" });
            return error;
        }

        public static ValidationResult ExceptionError<T>(string messageError)
        {
            var error = new ValidationResult();
            error.Errors.Add(new ValidationFailure() { ErrorMessage = $"{typeof(T).Name}: {messageError}" });
            return error;
        }
    }
}
