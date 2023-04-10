using System.ComponentModel.DataAnnotations;

namespace MoviesAPi.Data.Dtos;

public class CreateAdressDto
{
    [Required]
    public string PublicPlace { get; set; }

    [Required]
    public int Number { get; set; }
    
}