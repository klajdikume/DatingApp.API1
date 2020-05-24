using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //create mappings
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt
                .MapFrom(src => src.Photos
                .FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateofBirth
                .CalculateAge())); 

            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt
                .MapFrom(src => src.Photos
                .FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateofBirth
                .CalculateAge()));

            CreateMap<Photo, PhotosForDetailedDto>();

            CreateMap<UserForUpdateDto, User>();

            CreateMap<Photo, PhotoForReturnDto>();

            CreateMap<PhotoForCreationDto, Photo>();

            CreateMap<UserForRegisterDto, User>();
        }
    }
}
