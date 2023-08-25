using AutoMapper;
using FilmesApiRest.Data;
using FilmesApiRest.Data.Dtos;
using FilmesApiRest.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApiRest.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarCinema([FromBody] CreateCinemaDto dto)
    {
        Cinema cinema = _mapper.Map<Cinema>(dto);
        _context.cinemas.Add(cinema);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperaCinemaPorId), new { id = cinema.Id }, cinema);
           
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> ListarCinemas([FromQuery] int skip = 0, [FromQuery] int take = 20) 
    {
        return _mapper.Map<List<ReadCinemaDto>>(_context.cinemas.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaCinemaPorId(int id) 
    {
        Cinema cinema = _context.cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null) 
        {
            return NotFound();
        }
        var cinemaDto = _mapper.Map<Cinema>(cinema);
        return Ok(cinemaDto);
    } 
    
    [HttpPut("{id}")]
    public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDto dto) 
    {
        Cinema cinema = _context.cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null) return NotFound();
        _mapper.Map(dto, cinema);
        _context.SaveChanges();
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoverCinema(int id) 
    {
        var cinema = _context.cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if(cinema == null) return NotFound();
        _context.cinemas.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }
}
