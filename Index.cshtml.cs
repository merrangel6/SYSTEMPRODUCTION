using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PiaIndustrial.Data;
using PiaIndustrial.Models;
using System.Text.Json;

namespace PiaIndustrial.Pages;

public class IndexModel(IndustrialDbContext context) : PageModel
{
    public int ActiveOrders { get; set; }
    public int PlannedUnits { get; set; }
    public int ProducedUnits { get; set; }
    public int LowStockMaterials { get; set; }
    public int AvailableTools { get; set; }
    public int ActiveEmployees { get; set; }
    public string ProductionChartLabelsJson { get; set; } = "[]";
    public string ProductionChartDataJson { get; set; } = "[]";
    public string ToolChartLabelsJson { get; set; } = "[]";
    public string ToolChartDataJson { get; set; } = "[]";
    public IList<ProductionOrder> RecentOrders { get; set; } = [];
    public IList<Material> LowStockList { get; set; } = [];

    public async Task OnGetAsync()
    {
        var activeStatuses = new[] { ProductionStatus.Planeada, ProductionStatus.EnProceso, ProductionStatus.Pausada };

        ActiveOrders = await context.ProductionOrders.CountAsync(x => activeStatuses.Contains(x.Status));
        PlannedUnits = await context.ProductionOrders.SumAsync(x => (int?)x.PlannedQuantity) ?? 0;
        ProducedUnits = await context.ProductionOrders.SumAsync(x => (int?)x.ProducedQuantity) ?? 0;
        LowStockMaterials = await context.Materials.CountAsync(x => x.Stock <= x.ReorderPoint);
        AvailableTools = await context.Tools.SumAsync(x => (int?)x.StockDisponible) ?? 0;
        ActiveEmployees = await context.Employees.CountAsync(x => x.Estado == "Activo");
        LowStockList = await context.Materials.Where(x => x.Stock <= x.ReorderPoint).OrderBy(x => x.Stock).ToListAsync();
        RecentOrders = await context.ProductionOrders
            .Include(x => x.Product)
            .Include(x => x.Machine)
            .OrderByDescending(x => x.ScheduledDate)
            .Take(6)
            .ToListAsync();

        var productionByStatus = await context.ProductionOrders
            .GroupBy(x => x.Status)
            .Select(x => new { Status = x.Key.ToString(), Total = x.Sum(y => y.PlannedQuantity) })
            .ToListAsync();

        var toolsByCategory = await context.Tools
            .GroupBy(x => x.Categoria)
            .Select(x => new { Categoria = x.Key, Total = x.Sum(y => y.StockDisponible) })
            .ToListAsync();

        ProductionChartLabelsJson = JsonSerializer.Serialize(productionByStatus.Select(x => x.Status));
        ProductionChartDataJson = JsonSerializer.Serialize(productionByStatus.Select(x => x.Total));
        ToolChartLabelsJson = JsonSerializer.Serialize(toolsByCategory.Select(x => x.Categoria));
        ToolChartDataJson = JsonSerializer.Serialize(toolsByCategory.Select(x => x.Total));
    }
}
