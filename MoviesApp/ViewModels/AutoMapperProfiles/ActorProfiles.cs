using AutoMapper;
using MoviesApp.ViewModels.Actor;

namespace MoviesApp.ViewModels.AutoMapperProfiles
{
    public class ActorProfile: Profile
    {
        public ActorProfile()
        {
            CreateMap<Models.Actor, InputActorViewModel>().ReverseMap();
            CreateMap<Models.Actor, DeleteActorViewModel>();
            CreateMap<Models.Actor, EditActorViewModel>().ReverseMap();
            CreateMap<Models.Actor, ActorViewModel>();
        }
    }
}