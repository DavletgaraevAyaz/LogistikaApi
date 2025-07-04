using Microsoft.AspNetCore.Mvc;

namespace LogistikaApi.Interface
{
    public interface IDashboardService
    {
        Task<IActionResult> GetOverviewAsync();
        Task<IActionResult> GetAlertsAsync();
        Task<IActionResult> GetStatisticsAsync();
    }

}
