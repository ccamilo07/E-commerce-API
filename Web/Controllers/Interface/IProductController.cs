using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IProductController
    {
        Task<ActionResult<IEnumerable<Product>>> GetAll();
        Task<ActionResult<Product>> GetById(int id);
        Task<ActionResult<Product>> Save([FromBody] Product product);
        Task<IActionResult> Update([FromBody] Product product);
        Task<IActionResult> Delete(int id);
    }

}
