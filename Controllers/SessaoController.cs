using AutoMapper;
using FilmesApiRest.Data;
using FilmesApiRest.Data.Dtos;
using FilmesApiRest.Models;
using Microsoft.AspNetCore.Mvc;


namespace FilmesApiRest.Controllers;

[ApiController]
[Route("[controller]")]
public class SessaoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public SessaoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ReadSessaoDto> ListarSessoes() 
    {
        return _mapper.Map<List<ReadSessaoDto>>(_context.sessoes.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult ListarSessoesPoriD(int id)
    {
        var sessao = _context.sessoes.FirstOrDefault(sessao => sessao.Id == id);
        if (sessao == null) return NotFound();
        _mapper.Map<ReadSessaoDto>(sessao);
        return Ok();
    }

    [HttpPost]
    public IActionResult AdicionarSessao([FromBody] CreateSessaoDto dto)
    {
        Sessao sessao = _mapper.Map<Sessao>(dto);
        _context.sessoes.Add(sessao);
        _context.SaveChanges();

        return CreatedAtAction(nameof(ListarSessoesPoriD), new { id = sessao.Id }, sessao);

    }


}
