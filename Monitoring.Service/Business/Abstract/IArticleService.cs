using Monitoring.Service.Entities.Dtos;
using Monitoring.Service.Entities.Models;

namespace Monitoring.Service.Business.Abstract
{
    public interface IArticleService : IServiceBase<Article, ArticleCreateDto, ArticleUpdateDto, string>
    {
    }
}