using System.ComponentModel.DataAnnotations;

namespace PiaIndustrial.Models;

public class Tool
{
    public int Id { get; set; }

    [Required, StringLength(30)]
    public string Codigo { get; set; } = string.Empty;

    [Required, StringLength(120)]
    public string Nombre { get; set; } = string.Empty;

    [Required, StringLength(80)]
    public string Categoria { get; set; } = string.Empty;

    [Range(0, 999999)]
    public int Stock { get; set; }

    [Range(0, 999999)]
    public int StockDisponible { get; set; }

    [Required, StringLength(30)]
    public string Estado { get; set; } = "Disponible";

    public ICollection<ToolLoan> Loans { get; set; } = new List<ToolLoan>();
}
