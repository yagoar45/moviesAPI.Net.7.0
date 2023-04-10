using System.ComponentModel.DataAnnotations;

namespace MoviesAPi.Data.Dtos;

public class UpdateAdressDto
{

    [Required]
    public string PublicPlace { get; set; }

    [Required]
    public int Number { get; set; }

}