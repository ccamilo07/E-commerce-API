using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;

namespace Web.Controllers.Implemetation
{
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersBusiness _ordersBusiness;

        public OrdersController(IOrdersBusiness ordersBusiness)
        {
            _ordersBusiness = ordersBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            try
            {
                var orders = await _ordersBusiness.GetAll();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (OrdersController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            try
            {
                var order = await _ordersBusiness.GetById(id);
                if (order == null) return NotFound("Orden no encontrada.");
                return Ok(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (OrdersController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Save([FromBody] Order order)
        {
            try
            {
                var newOrder = await _ordersBusiness.Save(order);
                return CreatedAtAction(nameof(GetById), new { id = newOrder.Id }, newOrder);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (OrdersController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Order order)
        {
            try
            {
                await _ordersBusiness.Update(order);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (OrdersController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ordersBusiness.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (OrdersController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }

}
