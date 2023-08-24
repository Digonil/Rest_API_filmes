using System.ComponentModel.DataAnnotations;

namespace FilmesApiRest.Data.Dtos;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "O campo de nome é obrigatório.")]
    public string Nome { get; set; }
}
