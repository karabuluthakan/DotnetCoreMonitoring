using Monitoring.Service.DataAccess.Abstract;
using Monitoring.Service.Entities.Models; 

namespace Monitoring.Service.DataAccess.Concrete.MongoDb
{
    public class MongoDbArticleDal : MongoRepositoryBase<Article>, IArticleRepository
    {
    }
}