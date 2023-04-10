using System.ComponentModel.DataAnnotations;

namespace MoviesAPi.Data.Dtos;

// classe para atualizar os valores no banco 
public class UpdateMovieDto
{
    // criando props exclusivas da classe Movie para transição de dados 
    [Required(ErrorMessage = "O título do filme é obrigatório !")]
    [StringLength(90, ErrorMessage = "O título só pode ter, no máximo, 90 caracteres.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "O gênero do filme é obrigatório !")]
    [StringLength(50, ErrorMessage = "O título só pode ter, no máximo, 50 caracteres")]
    public string Genre { get; set; }

    [Required(ErrorMessage = "A duração do filme é obrigatório !")]
    [Range(70, 600, ErrorMessage = "Para ser considerado um filme, ele deve ter entre 70 a 600 minutos.")]
    public int Duration { get; set; }
}