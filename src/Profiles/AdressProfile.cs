using System.Data.Common;
using AutoMapper;
using MoviesAPi.Data.Dtos;
using MoviesAPi.Models;

namespace MoviesAPi.Profiles;

public class AdressProfile : Profile
{
    // criando as conversões de DTOS em objetos e vice-versa
    // para a classe MovieTheater
    public AdressProfile()
    {    
        CreateMap<CreateAdressDto,Adress>();
        CreateMap<Adress, ReadAdressDto>();
        CreateMap<UpdateAdressDto, Adress>();
    }
}