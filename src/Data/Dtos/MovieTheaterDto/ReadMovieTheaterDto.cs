using System.ComponentModel.DataAnnotations;

namespace MoviesAPi.Data.Dtos;

// SOMENTE LEITURA DO DTO 
public class ReadMovieTheaterDto
{
  
    public int Id {get; set;}

    public string Name {get; set;}

    // usado para linkar as tabelas 
    public ReadAdressDto ReadAdressDto {get; set;}
}