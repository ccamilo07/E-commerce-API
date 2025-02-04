using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface ICityController
    {
        Task<ActionResult<IEnumerable<City>>> GetAll();
        Task<ActionResult<City>> GetById(int id);
        Task<ActionResult<City>> Save([FromBody] City city);
        Task<IActionResult> Update([FromBody] City city);
        Task<IActionResult> Delete(int id);
    }

}
