using AutoMapper;
using MoviesAPi.Data.Dtos;
using MoviesAPi.Models;

namespace MoviesAPi.Profiles;

// indicando que essa classe irá fazendo o automapper da movie 
public class MovieProfile : Profile
{
    public MovieProfile()
    {
        // possibilita a mudança de um DTO para o tipo específico nos 2 primeiros casos
        // e o inverso nos 2 últimos  
        CreateMap<CreateMovieDto,Movie>();
        CreateMap<UpdateMovieDto, Movie>();
        CreateMap<Movie, UpdateMovieDto>();
        CreateMap<Movie,ReadMovieDto>();
    }
}