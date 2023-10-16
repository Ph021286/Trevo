
using System.ComponentModel.DataAnnotations;

namespace Projeto1.Models;

public partial class ElencoMasculino
{
    [Key]
    public int Matricula { get; set; }

    public string? Nome { get; set; }

    public string? Posicao { get; set; }


    public ElencoMasculino()
    {

    }

    public ElencoMasculino(int matricula, string? nome, string? posição)
    {
        Matricula = matricula;
        Nome = nome;
        Posicao = posição;
    }
}