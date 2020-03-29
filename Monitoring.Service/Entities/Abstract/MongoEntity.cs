using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Monitoring.Service.Entities.Abstract
{
    public abstract class MongoEntity : IEntity<string>
    {
        protected MongoEntity()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        [BsonElement(Order = 0)]
        public string Id { get; }


        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonElement(Order = 1)]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    }
}