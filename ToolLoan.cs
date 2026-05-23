using System.ComponentModel.DataAnnotations;

namespace PiaIndustrial.Models;

public class ToolLoan
{
    public int Id { get; set; }

    [Range(1, 999999)]
    public int Cantidad { get; set; } = 1;

    public DateTime FechaPrestamo { get; set; } = DateTime.Now;

    public DateTime? FechaDevolucion { get; set; }

    [Required, StringLength(30)]
    public string Estado { get; set; } = "Prestado";

    [StringLength(180)]
    public string? Observaciones { get; set; }

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public int ToolId { get; set; }
    public Tool? Tool { get; set; }
}
