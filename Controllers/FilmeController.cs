using AutoMapper;
using FilmesApiRest.Data;
using FilmesApiRest.Data.Dtos;
using FilmesApiRest.Models;
using Microsoft.AspNetCore.JsonPatch;
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
    [ProducesResponseType(StatusCodes.Status201Created)]
    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto dto)
    {
        Filme filme = _mapper.Map<Filme>(dto);
        _context.filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFimePorId), new {id = filme.Id}, filme);
        
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> RecuperaFilmes([FromQuery] int skip=0, [FromQuery] int take=20)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.filmes.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFimePorId(int id) 
    {
        var filme = _context.filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            return NotFound();
        }

        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);

    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme([FromBody] UpdateFilmeDto filmeDto , int id) 
    {
        var filme = _context.filmes.FirstOrDefault(filme => filme.Id == id);
        if(filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(JsonPatchDocument<UpdateFilmeDto> patch, int id)
    {
        var filme = _context.filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        _context.filmes.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}

