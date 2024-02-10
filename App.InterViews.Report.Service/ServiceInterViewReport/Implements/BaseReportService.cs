using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Implements
{
    public class BaseReportService<Entity, TOut> : IReportServiceBase<TOut> where TOut : BaseDto
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Entity> _iRepositoryBase;

        public BaseReportService(IRepositoryBase<Entity> iRepositoryBase, IMapper mapper)
        {
            _mapper = mapper;
            _iRepositoryBase = iRepositoryBase;
        }

        public virtual async Task<Result<TOut, ErrorResult>> Add(TOut dto)
        {
            var entity = _mapper.Map<Entity>(dto);
            var result = await _iRepositoryBase.AddAsync(entity);

            return result.Map(val =>
            {
                return _mapper.Map<TOut>(val);
            });
        }

        public virtual async Task<Result<TOut, ErrorResult>> Delete(Guid id)
        {
            var response = await _iRepositoryBase.DeleteAsync(id);

            return response.Map(val =>
            {
                return _mapper.Map<TOut>(val);
            });
        }

        public virtual Result<IEnumerable<TOut>, ErrorResult> GetAll()
        {
            var entities = _iRepositoryBase.GetAll();

            return entities.Map(value =>
            {
                return _mapper.Map<IEnumerable<TOut>>(value);
            });
        }

        public virtual async Task<Result<TOut, ErrorResult>> GetById(Guid id)
        {
            var value = await _iRepositoryBase.GetByIdAsync(id);

            return value.Map(val =>
            {
                return _mapper.Map<TOut>(val);
            });
        }

        public async Task<Result<TOut, ErrorResult>> Update(TOut dto)
        {
            var value = await _iRepositoryBase.GetByIdAsync(dto.Id);

            if (value.IsSuccess)
            {
                var entity = _mapper.Map<Entity>(dto);
                var response = _iRepositoryBase.Update(entity);

                return response.Map(val =>
                {
                    return _mapper.Map<TOut>(val);
                });
            }

            return value.Error;
        }
    }
}
