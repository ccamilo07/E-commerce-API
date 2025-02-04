using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface ICartController
    {
        Task<ActionResult<IEnumerable<Cart>>> GetAll();
        Task<ActionResult<Cart>> GetById(int id);
        Task<ActionResult<Cart>> Save([FromBody] Cart cart);
        Task<IActionResult> Update([FromBody] Cart cart);
        Task<IActionResult> Delete(int id);
    }

}
