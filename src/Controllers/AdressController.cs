using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPi.Data;
using MoviesAPi.Data.Dtos;
using MoviesAPi.Models;

namespace MoviesAPi.Controllers;

[ApiController]
[Route("[controller]")]
public class AdressController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;


    public AdressController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AddAdress([FromBody] CreateAdressDto adressDto)
    {

        Adress adress = _mapper.Map<Adress>(adressDto);


        _context.Adresses.Add(adress);


        _context.SaveChanges();


        return CreatedAtAction(nameof(ReturnAdressForId), new { Id = adress.Id }, adress);
    }


    [HttpGet]
    public IEnumerable<ReadAdressDto> ReturnAdresses()
    {

        return _mapper.Map<List<ReadAdressDto>>(_context.Adresses.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult ReturnAdressForId(int id)
    {
        Adress adress = _context.Adresses.FirstOrDefault(adress => adress.Id == id);

        if (adress != null)
        {
            ReadAdressDto adressDto = _mapper.Map<ReadAdressDto>(adress);
            return Ok(adress);
        }

        else return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAdress(int id, [FromBody] UpdateAdressDto adressDto)
    {
        Adress adress = _context.Adresses.FirstOrDefault(adress => adress.Id == id);

        if (adress == null) return NotFound();

        else
        {
            _mapper.Map(adressDto, adress);
            _context.SaveChanges();
            return NoContent();
        }
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteAdress(int id)
    {
        Adress adress = _context.Adresses.FirstOrDefault(adress => adress.Id == id);

        if (adress == null) return NotFound();

        else
        {
            _context.Remove(adress);
            _context.SaveChanges();
            return NoContent();
        }
    }
}