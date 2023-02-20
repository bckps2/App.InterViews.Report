using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.ValueTasks;
using FluentValidation.Results;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace App.InterViews.Report.Http;

public sealed class AutoMapperHttp : IAutoMapperHttp
{
    public IResult Ok<TOutput, TValidation>(Result<TOutput, TValidation> result)
        where TOutput : class where TValidation : ValidationResult
        => result.Match(
            onSuccess: Results.Ok,
            onFailure: HttpResult
       );

    public IResult HttpResult<TValidation>(TValidation validation)
        where TValidation : ValidationResult
    {
        return Results.BadRequest(validation.Errors.Select(c => c.ErrorMessage));
    }
}
