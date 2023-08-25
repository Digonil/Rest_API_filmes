using AutoMapper;
using FilmesApiRest.Data.Dtos;
using FilmesApiRest.Models;

namespace FilmesApiRest.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<Endereco, ReadEnderecoDto>();
        CreateMap<UpdateEnderecoDto, Endereco>();
    }
    
}
