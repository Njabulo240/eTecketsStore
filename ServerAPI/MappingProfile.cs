using AutoMapper;
using ServerAPI.Entities.DataTransferObjects;
using ServerAPI.Entities.Models;

namespace ServerAPI
{
 public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Actor, ActorDto>();
        CreateMap<Producer, ProducerDto>();
        CreateMap<Movie, MovieDto>();
        CreateMap<Cinema, CinemaDto>();

        CreateMap<Actor_Movie, Actor_MovieDto>();
    }
}
}