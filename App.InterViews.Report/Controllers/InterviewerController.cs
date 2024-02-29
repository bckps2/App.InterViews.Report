using App.InterViews.Report.Http;
using App.InterViews.Report.Models.Interviewer;
using App.InterViews.Report.Service.Dtos.Interviewer;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.InterViews.Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewerController
    {
        private readonly IMapper _mapper;
        private readonly IAutoMapperHttp _iAutoMapperHttp;
        private readonly IInterviewerService _interviewerService;

        public InterviewerController(IMapper mapper, IInterviewerService interviewerService, IAutoMapperHttp iAutoMapperHttp)
        {
            _mapper = mapper;
            _iAutoMapperHttp = iAutoMapperHttp;
            _interviewerService = interviewerService;
        }

        [HttpPost("AddInterviewer")]
        [ProducesResponseType(typeof(InterviewerModel), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddInterview(InterviewerModel interviewerModel)
        {
            var interview = _mapper.Map<InterviewerDto>(interviewerModel);
            var result = await _interviewerService.Add(interview);
            return _iAutoMapperHttp.Created(result);
        }

        [HttpPut("UpdateInterview")]
        [ProducesResponseType(typeof(InterviewerModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateInterview(InterviewerUpdateModel interviewModel)
        {
            var interview = _mapper.Map<InterviewerDto>(interviewModel);
            var result = await _interviewerService.Update(interview);
            return _iAutoMapperHttp.Ok(result);
        }

        [HttpDelete("DeleteInterview/{interviewerId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteInterview(Guid interviewerId)
        {
            var result = await _interviewerService.Delete(interviewerId);
            return _iAutoMapperHttp.NoContent(result);
        }
    }
}
