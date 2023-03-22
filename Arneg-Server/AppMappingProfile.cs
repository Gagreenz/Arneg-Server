using Arneg_Server.Dtos.Product;
using Arneg_Server.Dtos.Review;
using Arneg_Server.Models;
using AutoMapper;
using System;

namespace Arneg_Server
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<ProductUpdateDto, Product>()
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null && !string.IsNullOrEmpty(srcMember.ToString()) && !string.IsNullOrEmpty(srcMember.ToString())));
            CreateMap<ReviewDto, Review>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Review, ReviewCreateDto>();
            CreateMap<ReviewCreateDto, Review>();
            CreateMap<ReviewCreateDto, ReviewUpdateDto>();
            CreateMap<ReviewUpdateDto, Review>()
                .ForMember(r => r.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null && !string.IsNullOrEmpty(srcMember.ToString())
                ));
        }
    }
}
