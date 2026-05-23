using System.ComponentModel.DataAnnotations;

namespace PiaIndustrial.Models;

public class Material
{
    public int Id { get; set; }

    [Required, StringLength(30)]
    public string Code { get; set; } = string.Empty;

    [Required, StringLength(120)]
    public string Name { get; set; } = string.Empty;

    [Required, StringLength(20)]
    public string Unit { get; set; } = "kg";

    [Range(0, 999999)]
    public decimal Stock { get; set; }

    [Range(0, 999999)]
    public decimal ReorderPoint { get; set; }

    public ICollection<MaterialConsumption> Consumptions { get; set; } = new List<MaterialConsumption>();
    public ICollection<InventoryMovement> Movements { get; set; } = new List<InventoryMovement>();
}
