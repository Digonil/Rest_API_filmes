using AutoMapper;
using FilmesApiRest.Data.Dtos;
using FilmesApiRest.Models;

namespace FilmesApiRest.Profiles;

public class CinemaProfile : Profile
{

    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(cinemaDto => cinemaDto.Endereco, 
            opt => opt.MapFrom(cinema => cinema.Endereco));
        CreateMap<UpdateCinemaDto, Cinema>();
    }
    


}
