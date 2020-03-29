using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Monitoring.Service.DataAccess.Abstract;
using Monitoring.Service.Entities.Abstract;
using Monitoring.Service.Utilities.Results.Abstract;
using Monitoring.Service.Utilities.Results.Concrete;
using Monitoring.Service.Utilities.Results.Helpers;

namespace Monitoring.Service.Business.Abstract
{
    public abstract class
        ManagerBase<TModel, TList, TView, TCreate, TUpdate, TKey> : IServiceBase<TModel, TCreate, TUpdate, TKey>
        where TModel : class, IEntity, new()
        where TList : class, IDto, new()
        where TView : class, IDto, new()
        where TCreate : class, IDto, new()
        where TUpdate : class, IDto, new()
        where TKey : IEquatable<TKey>
    {
        protected readonly IRepository<TModel, TKey> repository;
        protected readonly IMapper mapper;

        protected ManagerBase(IRepository<TModel, TKey> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public virtual IResult GetAllItems()
        {
            var data = repository.Get();
            return data == null
                ? ErrorResult(ResultStatus.NotFound, "NotFound")
                : new DataResult<IEnumerable<TList>>(mapper.Map<IEnumerable<TList>>(data.ToList()), ResultStatus.Ok,
                    data.ToList().Count);
        }

        public virtual async Task<IResult> GetItemByIdAsync(TKey id)
        {
            var data = await repository.GetFindById(id);
            return data == null
                ? ErrorResult(ResultStatus.NotFound, "NotFound")
                : new DataResult<TView>(mapper.Map<TView>(data), ResultStatus.Ok);
        }

        public virtual async Task CreateNewItemAsync(TCreate data)
        {
            await repository.Create(mapper.Map<TModel>(data));
        }

        public virtual async Task UpdateItemAsync(TKey key, TUpdate data)
        {
            await repository.Update(key, mapper.Map<TModel>(data));
        }

        public virtual async Task DeleteItemByIdAsync(TKey id)
        {
            await repository.Delete(id);
        }

        private static IResult ErrorResult(ResultStatus status, string message)
        {
            return new Result(status, message);
        }
    }
}