using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface ICountryController
    {
        Task<ActionResult<IEnumerable<Country>>> GetAll();
        Task<ActionResult<Country>> GetById(int id);
        Task<ActionResult<Country>> Save([FromBody] Country country);
        Task<IActionResult> Update([FromBody] Country country);
        Task<IActionResult> Delete(int id);
    }

}
