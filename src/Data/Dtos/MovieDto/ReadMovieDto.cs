using System.ComponentModel.DataAnnotations;

namespace MoviesAPi.Models;

/// <summary>
/// DTO para leitura do objeto Filme
/// </summary>
public class ReadMovieDto
{

    /// <summary>
    /// Identificador único do filme 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Título do filme 
    /// </summary>
    public string Title { get; set; } = "";

    /// <summary>
    /// Gênero do filme, que deve ter no máximo 50 caracteres 
    /// </summary>
    public string Genre { get; set; } = "";


    /// <summary>
    /// Duração do filme, que deve ser entre 70 a 600 minutos.
    /// </summary>
    public int Duration { get; set; } = 0;

    /// <summary>
    /// Mommento que a leitura foi feita do filme 
    /// </summary>
    // retorna o momento da consulta 
    public DateTime ConsultTime { get; set; } = DateTime.Now;
}
