using App.InterViews.Report.CrossCutting.Helper;
using CSharpFunctionalExtensions;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace App.InterViews.Report.Http;

public interface IAutoMapperHttp
{
    IResult Ok<TOutput, TValidation>(Result<TOutput, TValidation> result)
        where TOutput : class where TValidation : ErrorResult;

    IResult HttpResult<TValidation>(TValidation validation)
           where TValidation : ErrorResult;
}
