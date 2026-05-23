using System.ComponentModel.DataAnnotations;

namespace PiaIndustrial.Models;

public class InventoryMovement
{
    public int Id { get; set; }

    [Required, StringLength(20)]
    public string Type { get; set; } = "Entrada";

    [Range(0.01, 999999)]
    public decimal Quantity { get; set; }

    [StringLength(160)]
    public string Reference { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int MaterialId { get; set; }
    public Material? Material { get; set; }
}
