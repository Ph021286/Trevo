
using System.ComponentModel.DataAnnotations;

namespace Projeto1.Models;

public partial class Jogadores
{
    [Key]
    public int Matricula { get; set; }

    public string? Nome { get; set; }

    public string? Posicao { get; set; }


    public Jogadores()
    {

    }

    public Jogadores(int matricula, string? nome, string? posição)
    {
        Matricula = matricula;
        Nome = nome;
        Posicao = posição;
    }
}