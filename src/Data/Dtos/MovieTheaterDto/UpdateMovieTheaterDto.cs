using System.ComponentModel.DataAnnotations;

namespace MoviesAPi.Data.Dtos;


// SOMENTE ATUALIZAÇÃO DO DTO 
public class UpdateMovieTheaterDto
{
    [Required(ErrorMessage = "O nome do cinema é obrigatório")]
    public string Name {get; set;}
}