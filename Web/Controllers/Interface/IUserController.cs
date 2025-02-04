using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IUserController
    {
        Task<ActionResult<IEnumerable<User>>> GetAll();
        Task<ActionResult<User>> GetById(int id);
        Task<ActionResult<User>> Save([FromBody] User user);
        Task<IActionResult> Update([FromBody] User user);
        Task<IActionResult> Delete(int id);
    }

}
