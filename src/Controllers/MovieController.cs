using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPi.Data;
using MoviesAPi.Data.Dtos;
using MoviesAPi.Models;

namespace MoviesAPi.Controllers;

[ApiController] // definindo essa classe como controladora
[Route("[controller]")] // definindo essa rota como portadora do sufixo "controller"

// usando a herança para definir o controller
public class MovieController : Controller
{
    // criando as operações no banco a partir dos métodos instanciados do MovieContext
    private MovieContext _context;

    // decretando um campo para o automapper e colocando ele no construtor
    private IMapper _mapper;
    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    // o [FromBody] diz que o argumento vem da requisição web 
    public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
    {
        // aqui, haverá a mudança de um movieDto para um movie
        Movie movie = _mapper.Map<Movie>(movieDto);
        _context.Movies.Add(movie);

        // verificando se a alteração foi feita 
        _context.SaveChanges();

        Console.WriteLine($"Duração: {movie.Duration} minutos \n" + $"Título: {movie.Title}");

        // vai retornar o objeto criado e a localização do recurso URL dele no campo da requisição
        // argumento 1: nome da função que retornaria o objeto, caso ele já tivesse sido criado
        // argumento 2: cria uma parte desse objeto que é responsável pela identificação: no caso, é o id
        // argumento 3: relata o tipo de objeto, que é no caso um movie
        return CreatedAtAction(nameof(ReturnMovieForId), new { id = movie.Id }, movie);
    }

    // método GET para leitura dos filmes
    [HttpGet]
    public IEnumerable<Movie> ReturnMovies([FromQuery] int skip = 0, [FromQuery] int take = 12)
    {
        // skip => quantos dados quer pular, take => quantos dados quer pegar após o pulo
        // esses dados são pegos por uma query do método get, que fica na url da requisição no formato abaixo
        // "https://localhost:5001/Movie?skip=2&take=5"
        return _context.Movies.Skip(skip).Take(take);
    }

    // método GET para recuperar pelo id
    // caso não tenha, retorna um array nulo
    // o método será "Movie/id"
    [HttpGet("{id}")]
    public IActionResult ReturnMovieForId(int id)
    {
        // retorna o filme conforme o id passado
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        // se não houver, retorna o "Não encontrado"
        if (movie == null) return NotFound();

        // se for encontrado, retorna o filme
        return Ok(movie);
    }
}
