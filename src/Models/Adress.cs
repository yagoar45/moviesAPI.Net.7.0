using System.ComponentModel.DataAnnotations;

namespace MoviesAPi.Models;

public class Adress
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string PublicPlace { get; set; }

    [Required]
    public int Number { get; set; }

    // chave estrangeira que se relaciona com MovieTheater
    public virtual MovieTheater MovieTheater {get;set;}
}