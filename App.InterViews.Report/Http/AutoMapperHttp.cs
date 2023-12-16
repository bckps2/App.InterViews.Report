using App.InterViews.Report.CrossCutting.Helper;
using CSharpFunctionalExtensions;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace App.InterViews.Report.Http;

public sealed class AutoMapperHttp : IAutoMapperHttp
{
    public IResult Ok<TOutput, TValidation>(Result<TOutput, TValidation> result)
        where TOutput : class where TValidation : ErrorResult
        => result.Match(
            onSuccess: Results.Ok,
            onFailure: HttpResult
       );

    public IResult HttpResult<TValidation>(TValidation validation) where TValidation : ErrorResult
    => validation.StatusCode switch
    {
        System.Net.HttpStatusCode.NotFound => Results.NotFound(validation.Errors.Select(c => c.ErrorMessage)),
        System.Net.HttpStatusCode.BadRequest => Results.BadRequest(validation.Errors.Select(c => c.ErrorMessage)),
        _ => Results.Problem(validation.Errors.FirstOrDefault()?.ErrorMessage)
    };
}
