using AutoMapper;
using MoviesApp.Models;
using MoviesApp.Services.Actor.Dto;
using MoviesApp.ViewModels;

namespace MoviesApp.Services.Dto.AutoMapperProfiles
{
    public class ActorDtoProfile:Profile
    {
        public ActorDtoProfile()
        {
            CreateMap<Models.Actor, ActorDto>().ReverseMap();
        }
    }
}