using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using App.InterViews.Report.Models;
using AutoMapper;
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
            var company = _mapper.Map<ServiceCompanyModel>(companyModel);
            return Ok(_iInterViewReport.AddInterView(company));
        }

        [HttpPost("AddInterViewCompany")]
        public IActionResult AddInterViewCompany(InterviewModel interviewModel)
        {
            var interview = _mapper.Map<ServiceInterviewModel>(interviewModel);
            return Ok(_iInterViewReport.AddInterViewOfCompany(interview));
        }

        [HttpPost("AddInterViewInformation")]
        public IActionResult AddInterViewInformation(InformationInterViewModel interViewModel)
        {
            var informationInterView = _mapper.Map<ServiceInformationModel>(interViewModel);
            return Ok(_iInterViewReport.AddInterViewInformation(informationInterView));
        }


        [HttpPut("UpdateInterViewInformation")]
        public IActionResult UpdateInterViewInformation(InformationInterViewModel interViewModel)
        {
            var informationInterView = _mapper.Map<ServiceInformationModel>(interViewModel);
            return Ok(_iInterViewReport.UpdateInterViewInformation(informationInterView));
        }

        [HttpDelete("DeleteInformationInterview/{idInformation}")]
        public IActionResult DeleteInformationInterview(int idInformation) 
        {
            return Ok(_iInterViewReport.DeleteInformation(idInformation));
        }

        [HttpDelete("DeleteInterview/{idInterview}")]
        public IActionResult DeleteInterview(int idInterview) 
        {
            return Ok(_iInterViewReport.DeleteInterview(idInterview));
        }


        [HttpDelete("DeleteCompany/{idCompany}")]
        public IActionResult DeleteCompany(int idCompany)
        {
            return Ok(_iInterViewReport.DeleteCompany(idCompany));
        }
    }
}
