using System.ComponentModel.DataAnnotations;

namespace FilmesApiRest.Models;

public class Filme
{
    public int Id { get; set; }
    
    public string Titulo { get; set; }

    public string  Genero { get; set; }

    public string Diretor { get; set; }

    public int Duracao { get; set; } 

    public virtual ICollection<Sessao> Sessoes { get; set; }    
    

}
