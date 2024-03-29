﻿using App.InterViews.Report.CrossCutting.Helper;
using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.ValueTasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace App.InterViews.Report.Http;

public sealed class AutoMapperHttp : ControllerBase, IAutoMapperHttp
{
    private readonly HttpContext _context;

    public AutoMapperHttp(IHttpContextAccessor httpContextAccessor)
    {
        _context = httpContextAccessor.HttpContext!;
    }

    public IActionResult Ok<TOutput, TValidation>(Result<TOutput, TValidation> result)
        where TOutput : class where TValidation : ErrorResult
        => result.Match(
            onSuccess: Ok,
            onFailure: HttpResult
       );

    public IActionResult NoContent<TOutput, TValidation>(Result<TOutput, TValidation> result)
        where TOutput : class where TValidation : ErrorResult
        => result.Match(
            onSuccess: value => NoContent(),
            onFailure: HttpResult
       );

    public IActionResult Created<TOutput, TValidation>(Result<TOutput, TValidation> result)
        where TOutput : class where TValidation : ErrorResult
        => result.Match(
           onSuccess: value => Created(_context.Request.GetDisplayUrl(), value),
           onFailure: HttpResult
      );

    private IActionResult HttpResult<TValidation>(TValidation validation) 
        where TValidation : ErrorResult
        => validation.StatusCode switch
    {
        System.Net.HttpStatusCode.NotFound => NotFound(validation.Errors.Select(c => c.ErrorMessage)),
        System.Net.HttpStatusCode.BadRequest => BadRequest(validation.Errors.Select(c => c.ErrorMessage)),
        _ => Problem(validation.Errors.FirstOrDefault()?.ErrorMessage)
    };
}
