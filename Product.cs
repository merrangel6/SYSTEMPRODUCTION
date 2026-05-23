using System.ComponentModel.DataAnnotations;

namespace PiaIndustrial.Models;

public class Product
{
    public int Id { get; set; }

    [Required, StringLength(30)]
    public string Code { get; set; } = string.Empty;

    [Required, StringLength(120)]
    public string Name { get; set; } = string.Empty;

    [StringLength(40)]
    public string Unit { get; set; } = "pieza";

    [Range(0, 999999)]
    public decimal StandardCost { get; set; }

    public ICollection<ProductionOrder> ProductionOrders { get; set; } = new List<ProductionOrder>();
}
