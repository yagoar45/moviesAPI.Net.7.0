using System.Linq;
using System.Net.Mail;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPi.Data;
using MoviesAPi.Data.Dtos;
using MoviesAPi.Models;

namespace MoviesAPi.Controllers;

// define a classe como parte da camada controller
[ApiController]
[Route("[controller]")]
public class MovieTheaterController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    // realizando injeção de dependência
    public MovieTheaterController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // Criando o método POST
    [HttpPost]
    public IActionResult AddMovieTheater([FromBody] CreateMovieTheaterDto movieTheaterDto)
    {
        // recebe um movieTheaterDto da requisição e transforma em movieTheater
        MovieTheater movieTheater = _mapper.Map<MovieTheater>(movieTheaterDto);

        // adiciona o objeto criado no banco mysql
        _context.MovieTheaters.Add(movieTheater);

        // salva as mudanças feitas no banco
        _context.SaveChanges();

        // retorna o objeto criado com seu id e seu tipo
        return CreatedAtAction(nameof(ReturnMovieTheaterForId), new { Id = movieTheater.Id }, movieTheaterDto);
    }

    // criando método GET ALL
    // retorna enums dos cinemas do banco
    [HttpGet]
    public IEnumerable<ReadMovieTheaterDto> ReturnMovieTheaters()
    {
        // retorna os cinemas em forma de lista desses mesmos objetos 
        return _mapper.Map<List<ReadMovieTheaterDto>>(_context.MovieTheaters.ToList());
    }

    // Ccriando GET for id
    [HttpGet("{id}")]
    public IActionResult ReturnMovieTheaterForId(int id)
    {
        // Consulta LINQ para retornar o filme pelo id
        MovieTheater movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

        if (movieTheater != null)
        {
            // converte o objeto do banco em DTO e retorna no corpo da requisição
            ReadMovieTheaterDto movieTheaterDto = _mapper.Map<ReadMovieTheaterDto>(movieTheater);
            return Ok(movieTheater);
        }

        else return NotFound();
    }

    // Ccriando PUT for id
    [HttpPut("{id}")]
    public IActionResult UpdateMovieTheater(int id, [FromBody] UpdateMovieTheaterDto movieTheaterDto)
    {
        // Consulta LINQ para retornar o filme pelo id 
        MovieTheater movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

        if (movieTheater == null) return NotFound();

        else
        {
            // a partir do DTO enviado na requisição, ele
            // atualiza o objeto encontrado na consulta LINQ
            _mapper.Map(movieTheaterDto, movieTheater);
            _context.SaveChanges();
            return NoContent();
        }
    }


    // Criando o DELETE 
    [HttpDelete("{id}")]
    public IActionResult DeleteMovieTheater(int id)
    {
        MovieTheater movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

        if (movieTheater == null) return NotFound();

        else
        {
            _context.Remove(movieTheater);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
