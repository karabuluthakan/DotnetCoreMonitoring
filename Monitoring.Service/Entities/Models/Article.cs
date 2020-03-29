using System.Collections.Generic;
using Monitoring.Service.Entities.Abstract;

namespace Monitoring.Service.Entities.Models
{
    public class Article : MongoEntity
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
    }
}