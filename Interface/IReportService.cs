using Microsoft.AspNetCore.Mvc;

namespace LogistikaApi.Interface
{
    public interface IReportService
    {
        Task<IActionResult> GetStockReportAsync();
        Task<IActionResult> GetMovementsReportAsync();
        Task<IActionResult> GetReturnsReportAsync();
        Task<IActionResult> GetEfficiencyReportAsync();
    }

}
