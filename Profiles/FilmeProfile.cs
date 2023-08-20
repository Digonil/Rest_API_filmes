using AutoMapper;
using FilmesApiRest.Data.Dtos;
using FilmesApiRest.Models;

namespace FilmesApiRest.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();        
    }
}
