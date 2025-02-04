using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;

namespace Web.Controllers.Interface
{
    public interface IOrdersController
    {
        Task<ActionResult<IEnumerable<Orders>>> GetAll();
        Task<ActionResult<Orders>> GetById(int id);
        Task<ActionResult<Orders>> Save([FromBody] Orders orders);
        Task<IActionResult> Update([FromBody] Orders orders);
        Task<IActionResult> Delete(int id);
    }

}
