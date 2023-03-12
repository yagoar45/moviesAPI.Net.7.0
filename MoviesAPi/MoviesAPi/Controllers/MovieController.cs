using Microsoft.AspNetCore.Mvc;
using MoviesAPi.Models;

namespace MoviesAPi.Controllers;

// definindo essa classe como controladora
[ApiController]

// definindo essa rota como portadora do sufixo "controller"
[Route("[controller]")]

// usando a herança para definir o controller
public class MovieController : Controller   
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
        if (string.IsNullOrEmpty(movie.Title) && string.IsNullOrEmpty(movie.Genre) && movie.Duration >= 70)
        {
            movies.Add(movie);
            Console.WriteLine($"Duração: {movie.Duration} \n" + $"Título: {movie.Title}");
        }
    }
}
