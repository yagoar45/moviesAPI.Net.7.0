using Microsoft.AspNetCore.Mvc;
using MoviesAPi.Models;

namespace MoviesAPi.Controllers;

[ApiController] // definindo essa classe como controladora
[Route("[controller]")] // definindo essa rota como portadora do sufixo "controller"

// usando a herança para definir o controller
public class MovieController : ControllerBase   
{
    // criando lista estática na classe 
    private static List<Movie> movies = new List<Movie>();


    // lógica para adicionar filme no sistema
    // a partir do parâmetro movie 
    // define o método como post por meio do register
    [HttpPost]
    // o [FromBody] diz que o argumento vem da requisição web 
    public void AddMovie([FromBody] Movie movie)
    {
        movies.Add(movie);
        Console.WriteLine($"Duração: {movie.Duration} \n" + $"Título: {movie.Title}"); 
    }

    // método GET para leitura dos filmes
    [HttpGet]
    public IEnumerable<Movie> ReturnMovies()
    {
        return movies;
    }
}
