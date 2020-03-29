using System;
using System.Threading.Tasks;
using Monitoring.Service.Entities.Abstract;
using Monitoring.Service.Utilities.Results.Abstract;

namespace Monitoring.Service.Business.Abstract
{
    public interface IServiceBase<T, in TCreate, in TUpdate, in TKey>
        where T : class, IEntity, new()
        where TCreate : class, IDto, new()
        where TUpdate : class, IDto, new()
        where TKey : IEquatable<TKey>
    {
        IResult GetAllItems();

        Task<IResult> GetItemByIdAsync(TKey id);

        Task CreateNewItemAsync(TCreate data);

        Task UpdateItemAsync(TKey id, TUpdate data);

        Task DeleteItemByIdAsync(TKey id);
    }
}