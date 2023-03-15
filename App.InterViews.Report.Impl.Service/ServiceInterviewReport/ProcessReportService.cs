using AutoMapper;
using Microsoft.EntityFrameworkCore;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Db.Infrastructure.Context;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using FluentValidation.Results;
using CSharpFunctionalExtensions;
using App.InterViews.Report.Contract.Service.Dtos;

namespace App.InterViews.Report.Impl.Service.ServiceInterviewReport
{
    public class ProcessReportService<TValidation> : IProcessReportService<TValidation> where TValidation : ValidationResult
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Process, ValidationResult> _iRepositoryBaseInformation;
        private readonly DbDataContext _context;

        public ProcessReportService(IRepositoryBase<Process, ValidationResult> iRepositoryBaseInformation, IMapper mapper, DbDataContext context)
        {
            _context = context;
            _iRepositoryBaseInformation = iRepositoryBaseInformation;
            _mapper = mapper;
        }

        public List<Process>? GetAllWithInterviews() 
        {
            var processes = _context.Process?.Include(c => c.Interviews).ToList();
            return processes;
        }

        //public List<Process>? GetAll()
        //{
        //    return _iRepositoryBaseInformation.GetAll();
        //}

        public List<Process>? GetAllByIdCompany(int idInterview)
        {
            var processes = _context.Process?.Include(c => c.Interviews).Where(c => c.IdCompany == idInterview).ToList();
            //processes?.ForEach(process => process.Interviews?.ToList().ForEach(interview => interview.SetNameInterViewers()));
            return processes;
        }

        public async Task<Result<Process?, TValidation>> AddProcess(ServiceProcessDto informationModel)
        {
            var process = _mapper.Map<Process>(informationModel);
            return (await _iRepositoryBaseInformation.AddAsync(process)).Value;
        }

        //public Process? DeleteProcess(int processId)
        //{
        //    var information = _iRepositoryBaseInformation.GetById(processId);
        //    if (information != null)
        //    {
        //        var response = _iRepositoryBaseInformation.Delete(information);
        //        return response;
        //    }

        //    return null;
        //}
    }
}
