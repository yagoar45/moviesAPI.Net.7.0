using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPi.Data;
using MoviesAPi.Data.Dtos;
using MoviesAPi.Models;

namespace MoviesAPi.Controllers;


[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public SessionController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddSession( CreateSessionDto dto)
    {
        Session session = _mapper.Map<Session>(dto);
        _context.Sessions.Add(session);
        _context.SaveChanges();

        return CreatedAtAction(nameof(ReturnSessionForId), new {Id = session.Id}, session);
    }

    [HttpGet]
    public IEnumerable<ReadSessionDto> ReturnSessions()
    {
        return _mapper.Map<List<ReadSessionDto>>(_context.Sessions.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult ReturnSessionForId(int id)
    {
        Session session = _context.Sessions.FirstOrDefault(session => session.Id == id);

        if(session != null)
        {
            ReadSessionDto sessionDto = _mapper.Map<ReadSessionDto>(session);

            return Ok(sessionDto);
        }

        return NotFound();
    }
}