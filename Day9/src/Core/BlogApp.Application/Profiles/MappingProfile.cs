using AutoMapper;
using BlogApp.Application.DTOs;
using BlogApp.Domain;

namespace BlogApp.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogPost, BlogPostDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
        }
    }
}