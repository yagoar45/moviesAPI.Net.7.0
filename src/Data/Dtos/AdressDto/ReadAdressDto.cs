using System.ComponentModel.DataAnnotations;

namespace MoviesAPi.Data.Dtos;

public class ReadAdressDto
{

    public int Id { get; set; }

    [Required]
    public string PublicPlace { get; set; }

    [Required]
    public int Number { get; set; }

}