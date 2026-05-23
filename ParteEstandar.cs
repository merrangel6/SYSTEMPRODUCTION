using System.ComponentModel.DataAnnotations;

namespace PiaIndustrial.Models;

public class ParteEstandar
{
    public int Id { get; set; }

    [Required, StringLength(40)]
    public string NumeroParte { get; set; } = string.Empty;

    [Required, StringLength(120)]
    public string Producto { get; set; } = string.Empty;

    [Required, StringLength(300)]
    public string HerramientasNecesarias { get; set; } = string.Empty;

    [Required, StringLength(500)]
    public string Instrucciones { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(120)]
    public string ContactoSoporte { get; set; } = string.Empty;
}
