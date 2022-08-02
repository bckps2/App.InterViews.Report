using AutoMapper;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Library.Contracts;
using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;

namespace App.InterViews.Report.Impl.Service.ServiceInterviewReport
{
    public class InterviewInformationReportService : IInfomationInterviewReportService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<InformationInterView> _iRepositoryBaseInformation;

        public InterviewInformationReportService(IRepositoryBase<InformationInterView> iRepositoryBaseInformation, IMapper mapper)
        {
            _iRepositoryBaseInformation = iRepositoryBaseInformation;
            _mapper = mapper;
        }

        public List<InformationInterView>? GetAll()
        {
            return _iRepositoryBaseInformation.GetAll().ToList();
        }

        public List<InformationInterView>? GetAllByIdInterview(int idInterview)
        {
            var result = _iRepositoryBaseInformation.GetAll().Where(c => c.InterViewIdInterView == idInterview).ToList();
            result.ForEach(c => c.SetListInterViewers());
            return result;
        }

        public InformationInterView? AddInterViewInformation(ServiceInformationModel informationModel)
        {
            try
            {
                var information = _mapper.Map<InformationInterView>(informationModel);
                information.SetNameInterViewers();
                return _iRepositoryBaseInformation.Add(information).Value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public InformationInterView? UpdateInterViewInformation(ServiceInformationModel informationModel)
        {
            try
            {
                var informationDb = _iRepositoryBaseInformation.GetById(informationModel.IdInformation);
                if (informationDb != null)
                {
                    var information = _mapper.Map<InformationInterView>(informationModel);
                    information.SetNameInterViewers();
                    informationDb.InterViewersName = information.InterViewersName;
                    informationDb.Email = information.Email;
                    informationDb.Observations = information.Observations;
                    informationDb.DateInterView = information.DateInterView;
                    informationDb.TypeInterView = information.TypeInterView;
                    var response = _iRepositoryBaseInformation.Update(informationDb).Value;
                    response.SetListInterViewers();
                    return response;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public InformationInterView? DeleteInformation(int idInformation)
        {
            var information = _iRepositoryBaseInformation.GetById(idInformation);
            if (information != null)
            {
                var response = _iRepositoryBaseInformation.Delete(information);
                return response;
            }

            return null;
        }
    }
}
