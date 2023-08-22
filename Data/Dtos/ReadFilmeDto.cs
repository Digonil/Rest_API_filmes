﻿using System.ComponentModel.DataAnnotations;

namespace FilmesApiRest.Data.Dtos;

public class ReadFilmeDto
{
   
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public string Diretor { get; set; }
    public int Duracao { get; set; }
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}
