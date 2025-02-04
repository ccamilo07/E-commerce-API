using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IInventoryController
    {
        Task<ActionResult<IEnumerable<Inventory>>> GetAll();
        Task<ActionResult<Inventory>> GetById(int id);
        Task<ActionResult<Inventory>> Save([FromBody] Inventory inventory);
        Task<IActionResult> Update([FromBody] Inventory inventory);
        Task<IActionResult> Delete(int id);
    }

}
