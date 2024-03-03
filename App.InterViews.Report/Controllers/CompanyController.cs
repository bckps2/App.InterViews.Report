using App.InterViews.Report.Http;
using App.InterViews.Report.Models;
using App.InterViews.Report.Service.Dtos.Company;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.InterViews.Report.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController
{
    private readonly IMapper _mapper;
    private readonly IAutoMapperHttp _iAutoMapperHttp;
    private readonly ICompanyReportService _iServiceCompany;

    public CompanyController(ICompanyReportService iServiceCompany, IMapper mapper, IAutoMapperHttp iAutoMapperHttp)
    {
        _mapper = mapper;
        _iServiceCompany = iServiceCompany;
        _iAutoMapperHttp = iAutoMapperHttp;
    }

    [HttpGet("{companyId}")]
    [ProducesResponseType(typeof(CompanyDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByIdAsync([FromQuery] Guid companyId)
    {
        var result = await _iServiceCompany.GetByIdAsync(companyId);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(typeof(IEnumerable<CompanyDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllByUserId([FromQuery] Guid userId)
    {
        var result = await _iServiceCompany.GetAllByUserId(userId);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpGet("All")]
    [ProducesResponseType(typeof(IEnumerable<CompanyUserDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _iServiceCompany.GetAllAsync();
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(CompanyDto), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> AddAsync([FromBody] CompanyModel companyModel)
    {
        var company = _mapper.Map<CompanyDto>(companyModel);
        var result = await _iServiceCompany.AddAsync(company);
        return _iAutoMapperHttp.Created(result);
    }

    [HttpDelete("{idCompany}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteAsync([FromQuery] Guid idCompany)
    {
        var result = await _iServiceCompany.DeleteAsync(idCompany);
        return _iAutoMapperHttp.NoContent(result);
    }
}
