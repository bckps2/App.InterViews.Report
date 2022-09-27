using AutoMapper;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using App.InterViews.Report.Db.Infrastructure.Context;

namespace App.InterViews.Report.Impl.Service.ServiceInterviewReport
{
    public class ProcessReportService : IProcessReportService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Process> _iRepositoryBaseInformation;
        private readonly DbDataContext _context;

        public ProcessReportService(IRepositoryBase<Process> iRepositoryBaseInformation, IMapper mapper, DbDataContext context)
        {
            _context = context;
            _iRepositoryBaseInformation = iRepositoryBaseInformation;
            _mapper = mapper;
        }

        public List<Process>? GetAllWithInterviews() 
        {
            return _context.Process?.Include(c => c.Interviews).ToList();
        }

        public List<Process>? GetAll()
        {
            return _iRepositoryBaseInformation.GetAll().ToList();
        }

        public List<Process>? GetAllByIdCompany(int idInterview)
        {
            var result = _context.Process?.Include(c => c.Interviews).Where(c => c.IdCompany == idInterview).ToList();
            return result;
        }

        public Process? AddProcess(ServiceProcessModel informationModel)
        {
            try
            {
                var process = _mapper.Map<Process>(informationModel);
                return _iRepositoryBaseInformation.Add(process).Value;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public Process? DeleteProcess(int processId)
        {
            var information = _iRepositoryBaseInformation.GetById(processId);
            if (information != null)
            {
                var response = _iRepositoryBaseInformation.Delete(information);
                return response;
            }

            return null;
        }
    }
}
