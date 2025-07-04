using Microsoft.AspNetCore.Mvc;

namespace LogistikaApi.Interface
{
    public interface IMovementTypeService
    {
        Task<IActionResult> GetAllAsync();
    }

}
