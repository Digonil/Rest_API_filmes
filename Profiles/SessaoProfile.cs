using AutoMapper;
using FilmesApiRest.Data.Dtos;
using FilmesApiRest.Models;

namespace FilmesApiRest.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>();
        }
        
    }
}
