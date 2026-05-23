using System.ComponentModel.DataAnnotations;

namespace PiaIndustrial.Models;

public class Employee
{
    public int Id { get; set; }

    [Required, StringLength(120)]
    public string Nombre { get; set; } = string.Empty;

    [Required, StringLength(80)]
    public string Puesto { get; set; } = string.Empty;

    [Required, StringLength(40)]
    public string Turno { get; set; } = "Matutino";

    public DateTime FechaIngreso { get; set; } = DateTime.Today;

    [Required, StringLength(30)]
    public string Estado { get; set; } = "Activo";

    [StringLength(450)]
    public string? ApplicationUserId { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }

    public ICollection<ProductionOrder> ProductionOrders { get; set; } = new List<ProductionOrder>();
    public ICollection<ToolLoan> ToolLoans { get; set; } = new List<ToolLoan>();
}
