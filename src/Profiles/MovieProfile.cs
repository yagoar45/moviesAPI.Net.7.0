using AutoMapper;
using MoviesAPi.Data.Dtos;
using MoviesAPi.Models;

namespace MoviesAPi.Profiles;

// indicando que essa classe irá fazendo o automapper da movie 
public class MovieProfile : Profile
{
    public MovieProfile()
    {
        // fará a mudança de um DTO para o tipo movie 
        CreateMap<CreateMovieDto,Movie>();
    }
}