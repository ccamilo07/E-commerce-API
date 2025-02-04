using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;

namespace Web.Controllers.Interface
{
    public interface IOrdersController
    {
        Task<ActionResult<IEnumerable<Order>>> GetAll();
        Task<ActionResult<Order>> GetById(int id);
        Task<ActionResult<Order>> Save([FromBody] Order order);
        Task<IActionResult> Update([FromBody] Order order);
        Task<IActionResult> Delete(int id);
    }

}
