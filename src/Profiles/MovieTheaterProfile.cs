using System.Data.Common;
using AutoMapper;
using MoviesAPi.Data.Dtos;
using MoviesAPi.Models;

namespace MoviesAPi.Profiles;

public class MovieTheaterProfile : Profile
{
    // criando as conversões de DTOS em objetos e vice-versa
    // para a classe MovieTheater
    public MovieTheaterProfile()
    {
        CreateMap<CreateMovieTheaterDto, MovieTheater>();

        CreateMap<MovieTheater, ReadMovieTheaterDto>()
        // mapper exclusivo para mostrar que o adress do objeto MovieTheater
        // é o mesmo que o ReadAdressDto do objeto movieTheaterdto
        .ForMember(
                    movieTheaterdto => movieTheaterdto.ReadAdressDto,
                    opt => opt.MapFrom(MovieTheater => MovieTheater.Adress)
                    );

        CreateMap<UpdateMovieTheaterDto, MovieTheater>();
    }
}