using System.ComponentModel.DataAnnotations;

namespace MoviesAPi.Models;

public class Movie
{
    // criando props exclusivas da classe Movie

    [Key] // mostra que o Id é a primary key e é obrigatória
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O título do filme é obrigatório !")]
    [MaxLength(90, ErrorMessage = "O título só pode ter, no máximo, 90 caracteres.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "O gênero do filme é obrigatório !")]
    [MaxLength(50, ErrorMessage = "O título só pode ter, no máximo, 50 caracteres")]
    public string Genre { get; set; }

    [Required(ErrorMessage = "A duração do filme é obrigatório !")]
    [Range(70, 600, ErrorMessage = "Para ser considerado um filme, ele deve ter entre 70 a 600 minutos.")]
    public int Duration { get; set; }
    public virtual ICollection<Session> Sessions { get; set; }
}
