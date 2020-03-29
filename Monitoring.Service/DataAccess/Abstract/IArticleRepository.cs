using Monitoring.Service.Entities.Models;

namespace Monitoring.Service.DataAccess.Abstract
{
    public interface IArticleRepository : IMongoRepository<Article>
    {
    }
}