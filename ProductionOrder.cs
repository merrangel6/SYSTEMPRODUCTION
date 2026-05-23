using System.ComponentModel.DataAnnotations;

namespace PiaIndustrial.Models;

public class ProductionOrder
{
    public int Id { get; set; }

    [Required, StringLength(30)]
    public string OrderNumber { get; set; } = string.Empty;

    [Range(1, 999999)]
    public int PlannedQuantity { get; set; }

    [Range(0, 999999)]
    public int ProducedQuantity { get; set; }

    public DateTime ScheduledDate { get; set; } = DateTime.Today;

    public ProductionStatus Status { get; set; } = ProductionStatus.Planeada;

    [StringLength(240)]
    public string? Notes { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public int MachineId { get; set; }
    public Machine? Machine { get; set; }

    public int? EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public ICollection<MaterialConsumption> MaterialConsumptions { get; set; } = new List<MaterialConsumption>();
}
