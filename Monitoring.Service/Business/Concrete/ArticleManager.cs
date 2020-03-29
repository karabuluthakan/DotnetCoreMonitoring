using AutoMapper;
using Monitoring.Service.Business.Abstract;
using Monitoring.Service.DataAccess.Abstract;
using Monitoring.Service.Entities.Dtos;
using Monitoring.Service.Entities.Models;

namespace Monitoring.Service.Business.Concrete
{
    public class ArticleManager : ManagerBase<Article, ArticleListDto, ArticleViewDto, ArticleCreateDto,
        ArticleUpdateDto, string> , IArticleService
    {
        public ArticleManager(IArticleRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}