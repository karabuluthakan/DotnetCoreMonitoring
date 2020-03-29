using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Monitoring.Service.Entities.Abstract;


namespace Monitoring.Service.DataAccess.Abstract
{
    public abstract class MongoRepositoryBase<T> : IMongoRepository<T> where T : MongoEntity, new()
    {
        protected readonly IMongoCollection<T> Collection;

        protected MongoRepositoryBase()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("monitoring");
            this.Collection = db.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? Collection.AsQueryable()
                : Collection.AsQueryable().Where(filter);
        }

        public virtual Task<T> GetFindById(string id)
        {
            return Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public virtual Task Create(T data)
        {
            return Collection.InsertOneAsync(data);
        }

        public virtual Task Update(string id, T data)
        {
            return Collection.ReplaceOneAsync(x => x.Id == id, data);
        }

        public virtual Task Delete(string id)
        {
            return Collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}