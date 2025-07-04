using LogistikaApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace LogistikaApi.Interface
{
    public interface IDeliveryService
    {
        Task<IActionResult> GetAllAsync();
        Task<IActionResult> CreateAsync(Delivery delivery);
        Task<IActionResult> UpdateStatusAsync(int id, bool isDelivered);
    }

}
