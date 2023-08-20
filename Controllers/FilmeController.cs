using AutoMapper;
using FilmesApiRest.Data;
using FilmesApiRest.Data.Dtos;
using FilmesApiRest.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApiRest.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto dto)
    {
        Filme filme = _mapper.Map<Filme>(dto);
        _context.filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFimePorId), new {id = filme.Id}, filme);
        
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip=0, [FromQuery] int take=20)
    {
        return _context.filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFimePorId(int id) 
    {
        var filme = _context.filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            return NotFound();
        }
        return Ok(filme);

    }
}
