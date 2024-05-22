using app.Dtos.BlogDtos;
using app.Dtos.PostDtos;
using app.Models;
using AutoMapper;

namespace app
{
    public class AutoMapper : Profile
    {

        public AutoMapper()
        {
            CreateMap<Post, GetPostDto>();
            CreateMap<Blog, GetBlogDto>();
            CreateMap<CreateNewBlogDto, Blog>();
        }
    }
}