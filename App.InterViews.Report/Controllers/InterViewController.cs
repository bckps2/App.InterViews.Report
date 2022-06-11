using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.InterViews.Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterViewController : ControllerBase
    {
        private readonly IInterViewReportService _iInterViewReport;
        private readonly IMapper _mapper;


        public InterViewController(IInterViewReportService iInterViewReport, IMapper mapper)
        {
            _iInterViewReport = iInterViewReport;
            _mapper = mapper;
        }

        [HttpGet("GetAllInterViews")]
        public IActionResult GetAllInterViews()
        {
            return Ok(_iInterViewReport.GetAllInterViews());
        }

        [HttpPost("AddInterView")]
        public IActionResult AddInterView(CompanyModel companyModel)
        {
            var company = _mapper.Map<Company>(companyModel);
            return Ok(_iInterViewReport.AddInterView(company));
        }

        [HttpPut("UpdateInterViewInformation")]
        public IActionResult UpdateInterViewInformation(InformationInterViewModel interViewModel)
        {
            var informationInterView = _mapper.Map<InformationInterView>(interViewModel);
            return Ok(_iInterViewReport.UpdateInterViewInformation(informationInterView));
        }
    }
}
