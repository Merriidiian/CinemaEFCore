using System.Collections.Generic;
using MoviesApp.Models;
using MoviesApp.Services.Actor.Dto;
using MoviesApp.Services.Dto;

namespace MoviesApp.Services
{
    public interface IActorService
    {
        ActorDto GetActor(int id);
        ICollection<ActorDto> GetAllActors();
        ActorDto UpdateActor(ActorDto actorDto);
        ActorDto AddActor(ActorDto actorDto);
        ActorDto DeleteActor(int id);
    }
}