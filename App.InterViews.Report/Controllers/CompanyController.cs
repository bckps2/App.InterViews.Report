using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using App.InterViews.Report.Http;
using App.InterViews.Report.Models;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

namespace App.InterViews.Report.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : Controller
{
    private readonly IMapper _mapper;
    private readonly ICompanyReportService<Company> _iServiceCompany;
    private readonly IAutoMapperHttp _iAutoMapperHttp;

    public CompanyController(ICompanyReportService<Company> iServiceCompany, IMapper mapper, IAutoMapperHttp iAutoMapperHttp)
    {
        _mapper = mapper;
        _iServiceCompany = iServiceCompany;
        _iAutoMapperHttp = iAutoMapperHttp;
    }

    [HttpGet("GetCompanyById/{idCompany}")]
    public async Task<IResult> GetCompanyById(int idCompany)
    {
        var result = await _iServiceCompany.GetById(idCompany);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpGet("GetAllCompanies")]
    public IResult GetAllCompanies()
    {
        return _iAutoMapperHttp.Ok(_iServiceCompany.GetAll());
    }

    [HttpPost("AddCompany")]
    public async Task<IResult> AddCompany(CompanyModel companyModel)
    {
        var company = _mapper.Map<CompanyDto>(companyModel);
        var result = await _iServiceCompany.Add(company);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpDelete("DeleteCompany/{idCompany}")]
    public async Task<IResult> DeleteCompany(int idCompany)
    {
        var result = await _iServiceCompany.Delete(idCompany);
        return _iAutoMapperHttp.Ok(result);
    }
}
