using System.ComponentModel.DataAnnotations;

namespace FilmesApiRest.Data.Dtos;

public class CreateFilmeDto
{
    [Required(ErrorMessage = "O título do filme é obrigatório!!!")]
    [StringLength(100, ErrorMessage = "O tamanho máximo do título são 100 caracteres")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O gênero do filme é obrigatório!!!")]
    [StringLength(50, ErrorMessage = "O tamanho máximo do genêro são 50 caracteres.")]
    public string Genero { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "O tamanho máximo do nome do diretor são 50 caracteres.")]
    public string Diretor { get; set; }

    [Required]
    [Range(70, 600, ErrorMessage = "A duração do filme deve ter entre 70 e 600 minutos.")]
    public int Duracao { get; set; }
}
