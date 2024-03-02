using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Implements
{
    public class BaseReportService<Entity, TOut> : IBaseReportService<TOut> where TOut : BaseDto where Entity : BaseEntity 
    {
        protected readonly IMapper _mapper;
        protected readonly IRepositoryBase<Entity> _iRepository;

        public BaseReportService(IRepositoryBase<Entity> iRepositoryBase, IMapper mapper)
        {
            _mapper = mapper;
            _iRepository = iRepositoryBase;
        }

        public virtual async Task<Result<IEnumerable<TOut>, ErrorResult>> GetAllAsync()
        {
            var entities = await _iRepository.GetAllAsync();

            return entities.Map(value =>
            {
                return _mapper.Map<IEnumerable<TOut>>(value);
            });
        }

        public virtual async Task<Result<TOut, ErrorResult>> GetByIdAsync(Guid id)
        {
            var value = await _iRepository.GetByIdAsync(id);

            return value.Map(val =>
            {
                return _mapper.Map<TOut>(val);
            });
        }

        public virtual async Task<Result<TOut, ErrorResult>> AddAsync(TOut dto)
        {
            var entity = _mapper.Map<Entity>(dto);
            var result = await _iRepository.AddAsync(entity);

            return result.Map(val =>
            {
                return _mapper.Map<TOut>(val);
            });
        }

        public virtual async Task<Result<TOut, ErrorResult>> DeleteAsync(Guid id)
        {
            var response = await _iRepository.DeleteAsync(id);

            return response.Map(val =>
            {
                return _mapper.Map<TOut>(val);
            });
        }

        public virtual async Task<Result<TOut, ErrorResult>> UpdateAsync(TOut dto)
        {
            var value = await _iRepository.GetByIdAsync(dto.Id);

            if (value.IsSuccess)
            {
                dto.ModifyDate = DateTime.Now;
                dto.DateCreated = value.Value.DateCreated;

                var entity = _mapper.Map<Entity>(dto);
                var response = _iRepository.Update(entity);

                return response.Map(val =>
                {
                    return _mapper.Map<TOut>(val);
                });
            }

            return value.Error;
        }
    }
}
