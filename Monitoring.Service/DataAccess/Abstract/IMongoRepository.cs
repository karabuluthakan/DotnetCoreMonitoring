using Monitoring.Service.Entities.Abstract;

namespace Monitoring.Service.DataAccess.Abstract
{
    public interface IMongoRepository<T> : IRepository<T, string> where T : MongoEntity, new()
    {
    }
}