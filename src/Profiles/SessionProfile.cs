using AutoMapper;
using MoviesAPi.Data.Dtos;
using MoviesAPi.Models;

namespace MoviesAPi.Profiles;

public class SessionProfile : Profile
{
    public SessionProfile()
    {
        CreateMap<CreateSessionDto, Session>();
        CreateMap<Session, ReadSessionDto>();
    }
}