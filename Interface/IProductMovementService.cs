using LogistikaApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace LogistikaApi.Interface
{
    public interface IProductMovementService
    {
        Task<IActionResult> GetAllAsync();
        Task<IActionResult> GetByProductIdAsync(int productId);
        Task<IActionResult> GetByMovementTypeIdAsync(int movementTypeId);
        Task<IActionResult> CreateAsync(ProductMovement movement);
    }

}
