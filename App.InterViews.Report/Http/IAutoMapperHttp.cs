﻿using App.InterViews.Report.CrossCutting.Helper;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace App.InterViews.Report.Http;

public interface IAutoMapperHttp
{
    IActionResult Ok<TOutput, TValidation>(Result<TOutput, TValidation> result)
        where TOutput : class where TValidation : ErrorResult;

    IActionResult NoContent<TOutput, TValidation>(Result<TOutput, TValidation> result)
        where TOutput : class where TValidation : ErrorResult;
}
