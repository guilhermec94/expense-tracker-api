﻿using AutoMapper;
using ExpenseTrackerAPI.Model;
using ExpenseTrackerAPI.Repositories;
using ExpenseTrackerAPI.Utils;

namespace ExpenseTrackerAPI.Services
{
    public interface IBaseService<D> where D : class
    {
        public Task<(D dto, RequestResultStatus status)> Get(Guid id);
        public Task<(D dto, RequestResultStatus status)> Create(D dto);
        public Task<RequestResultStatus> Update(Guid id, D dto);
        public Task<RequestResultStatus> Delete(Guid id);
    }
    public abstract class BaseService<I, D> : IBaseService<D> where I : BaseEntity where D : class
    {
        protected IBaseRepository<I> repo { get; }
        protected IMapper _mapper { get; }

        public BaseService(IBaseRepository<I> repository, IMapper mapper)
        {
            repo = repository;
            _mapper = mapper;
        }

        public async Task<(D dto, RequestResultStatus status)> Get(Guid id)
        {
            var (res, status) = await repo.Get(id);
            return (_mapper.Map<D>(res), status);
        }

        public async Task<(D dto, RequestResultStatus status)> Create(D dto)
        {
            var entity = _mapper.Map<I>(dto);
            var (res, status) = await repo.Create(entity);
            return (_mapper.Map<D>(res), status);
        }

        public async Task<RequestResultStatus> Update(Guid id, D dto)
        {
            var (_, status) = await repo.Get(id);
            if (status == Utils.RequestResultStatus.NOT_FOUND)
            {
                return status;
            }

            var entity = _mapper.Map<I>(dto);
            entity.ID = id;
            var res = await repo.Update(entity);
            return res;
        }

        public async Task<RequestResultStatus> Delete(Guid id)
        {
            var (_, status) = await repo.Get(id);
            if (status == Utils.RequestResultStatus.NOT_FOUND)
            {
                return status;
            }

            return await repo.Delete(id);
        }
    }
}
