using AutoMapper;
using FilmesApiRest.Data;
using FilmesApiRest.Data.Dtos;
using FilmesApiRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesApiRest.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public EnderecoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> ListarEnderecos([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.enderecos.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult ListarEnderecoPorId(int id)
    {
        var endereco = _context.enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if(endereco == null) return NotFound();

        var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
        return Ok(enderecoDto);
    }

    [HttpPost]
    public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto dto)
    {
        var endereco = _mapper.Map<Endereco>(dto);
        _context.enderecos.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ListarEnderecoPorId), new { id = endereco.Id }, endereco);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto dto) 
    {
        var endereco = _context.enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();

        var enderecoAtualizado = _mapper.Map(dto, endereco);
        _context.SaveChanges();
        return NoContent();


    }

    [HttpDelete("{id}")]
    public IActionResult DeletarEndereco(int id) 
    {
        var endereco = _context.enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();

        _context.enderecos.Remove(endereco);
        return NoContent();
    }

}
