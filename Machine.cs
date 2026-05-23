using System.ComponentModel.DataAnnotations;

namespace PiaIndustrial.Models;

public class Machine
{
    public int Id { get; set; }

    [Required, StringLength(30)]
    public string Code { get; set; } = string.Empty;

    [Required, StringLength(120)]
    public string Name { get; set; } = string.Empty;

    [StringLength(80)]
    public string Area { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public ICollection<ProductionOrder> ProductionOrders { get; set; } = new List<ProductionOrder>();
}
