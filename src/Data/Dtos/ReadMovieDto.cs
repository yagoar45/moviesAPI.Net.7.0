using System.ComponentModel.DataAnnotations;

namespace MoviesAPi.Models;

public class ReadMovieDto
{
    // criando props exclusivas da classe ReadMovieDto
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }

    // retorna o momento da consulta 
    public DateTime ConsultTime {get; set;} = DateTime.Now;
}
