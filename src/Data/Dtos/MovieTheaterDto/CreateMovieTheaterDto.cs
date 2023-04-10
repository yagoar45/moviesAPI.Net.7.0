using System.ComponentModel.DataAnnotations;

namespace MoviesAPi.Data.Dtos;


/// <summary>
/// DTO relacionado com a criação do MovieTheater
/// </summary>
public class CreateMovieTheaterDto
{

    /// <summary>
    /// propriedade responsável pleo nome do cinema 
    /// </summary>
    [Required(ErrorMessage = "O nome do cinema é obrigatório")]
    public string Name {get; set;} = "";

    public int AdressId {get; set;}
}