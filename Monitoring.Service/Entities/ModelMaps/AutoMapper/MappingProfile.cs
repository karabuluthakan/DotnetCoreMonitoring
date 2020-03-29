using AutoMapper;
using Monitoring.Service.Entities.Dtos;
using Monitoring.Service.Entities.Models;

namespace Monitoring.Service.Entities.ModelMaps.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ArticleListDto, Article>().ReverseMap();
            CreateMap<ArticleViewDto, Article>().ReverseMap();
            CreateMap<ArticleCreateDto, Article>().ReverseMap();
            CreateMap<ArticleUpdateDto, Article>().ReverseMap();
        }
    }
}