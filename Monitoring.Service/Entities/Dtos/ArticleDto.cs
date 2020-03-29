using System.Collections.Generic;
using Monitoring.Service.Entities.Abstract;
using Monitoring.Service.Entities.Models;

namespace Monitoring.Service.Entities.Dtos
{
    public abstract class ArticleBaseDto : IDto
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public List<Tag> Tags { get; set; }
    }

    public class ArticleListDto : ArticleBaseDto
    {
    }

    public class ArticleViewDto : ArticleBaseDto
    {
        public string Id { get; set; }
    }

    public class ArticleCreateDto : ArticleBaseDto
    {
    }

    public class ArticleUpdateDto : ArticleBaseDto
    {
    }
}