using FilmesApiRest.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApiRest.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> opts)
        : base(opts)
    {
            
    }

    public DbSet<Filme> filmes { get; set; }
    public DbSet<Cinema> cinemas { get; set; }
}
