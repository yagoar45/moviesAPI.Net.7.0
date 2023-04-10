using System.ComponentModel.DataAnnotations;

namespace MoviesAPi.Data.Dtos;

/// <summary>
/// DTO relacionado com a criação do Filme
/// </summary>
public class CreateMovieDto
{

    /// <summary>
    /// Título do filme 
    /// </summary>
    [Required(ErrorMessage = "O título do filme é obrigatório !")]
    [StringLength(90, ErrorMessage = "O título só pode ter, no máximo, 90 caracteres.")]
    public string Title { get; set; } = "";


    /// <summary>
    /// Gênero do filme, que deve ter no máximo 50 caracteres 
    /// </summary>
    [Required(ErrorMessage = "O gênero do filme é obrigatório !")]
    [StringLength(50, ErrorMessage = "O título só pode ter, no máximo, 50 caracteres")]
    public string Genre { get; set; } = "";

    /// <summary>
    /// Duração do filme, que deve ser entre 70 a 600 minutos.
    /// </summary>
    [Required(ErrorMessage = "A duração do filme é obrigatório !")]
    [Range(70, 600, ErrorMessage = "Para ser considerado um filme, ele deve ter entre 70 a 600 minutos.")]
    public int Duration { get; set; } = 0;
}