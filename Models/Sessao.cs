using System.ComponentModel.DataAnnotations;

namespace FilmesApiRest.Models;

public class Sessao
{
    [Key]
    [Required]
    public int Id { get; set; }


}
