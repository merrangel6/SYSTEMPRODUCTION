using System.ComponentModel.DataAnnotations;

namespace PiaIndustrial.Models;

public class MaterialConsumption
{
    public int Id { get; set; }

    [Range(0.01, 999999)]
    public decimal Quantity { get; set; }

    public DateTime ConsumedAt { get; set; } = DateTime.Now;

    public int ProductionOrderId { get; set; }
    public ProductionOrder? ProductionOrder { get; set; }

    public int MaterialId { get; set; }
    public Material? Material { get; set; }
}
