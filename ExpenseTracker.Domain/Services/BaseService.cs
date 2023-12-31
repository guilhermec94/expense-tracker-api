﻿using AutoMapper;
using ExpenseTracker.CodeGen.Models;
using ExpenseTracker.Domain.Abstractions;
using ExpenseTracker.Domain.Common;
using ExpenseTracker.SharedKernel.Utils;

namespace ExpenseTracker.Domain.Services
{
    public abstract class BaseService<I, D> : IBaseService<D> where I : BaseEntity where D : class
    {
        protected IBaseRepository<I> repo { get; }
        protected IMapper _mapper { get; }

        public BaseService(IBaseRepository<I> repository, IMapper mapper)
        {
            repo = repository;
            _mapper = mapper;
        }

        public Task<(IEnumerable<D> data, PaginationDTO pagination)> GetAll(int? offset, int? limit)
        {
            var res = repo.GetAll(offset, limit);
            var pag = new PaginationDTO { Page = offset ?? 0, PerPage = limit ?? 0, TotalRecords = res.count };
            return Task.FromResult((res.data.Select(x => _mapper.Map<D>(x)), pag));
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
            if (status == RequestResultStatus.NOT_FOUND)
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
            if (status == RequestResultStatus.NOT_FOUND)
            {
                return status;
            }

            return await repo.Delete(id);
        }
    }
}
