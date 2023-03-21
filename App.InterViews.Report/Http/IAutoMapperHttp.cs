using CSharpFunctionalExtensions;
using FluentValidation.Results;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace App.InterViews.Report.Http;

public interface IAutoMapperHttp
{
    IResult Ok<TOutput, TValidation>(Result<TOutput, TValidation> result) 
        where TOutput : class where TValidation : ValidationResult;

    IResult HttpResult<TValidation>(TValidation validation)
           where TValidation : ValidationResult;
}
