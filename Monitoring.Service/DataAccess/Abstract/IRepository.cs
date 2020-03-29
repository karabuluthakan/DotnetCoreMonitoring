using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Monitoring.Service.Entities.Abstract;

namespace Monitoring.Service.DataAccess.Abstract
{
    public interface IRepository<T, in TKey>
        where T : class, IEntity, new()
        where TKey : IEquatable<TKey>
    {
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null);
        Task<T> GetFindById(TKey id);
        Task Create(T data);
        Task Update(TKey id,T data);
        Task Delete(TKey id);
    }
}