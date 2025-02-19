using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;

namespace Web.Controllers.Implemetation
{
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersBusiness _ordersBusiness;

        public OrdersController(IOrdersBusiness ordersBusiness)
        {
            _ordersBusiness = ordersBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetAll()
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

        [HttpGet("orders/{id}")]
        public async Task<ActionResult<Orders>> GetById(int id)
        {
            try
            {
                var orders = await _ordersBusiness.GetById(id);
                if (orders == null) return NotFound("Orden no encontrada.");
                return Ok(orders);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (OrdersController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Orders>> Save([FromBody] Orders orders)
        {
            try
            {
                var newOrders = await _ordersBusiness.Save(orders);
                return CreatedAtAction(nameof(GetById), new { id = newOrders.Id }, newOrders);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (OrdersController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Orders orders)
        {
            try
            {
                await _ordersBusiness.Update(orders);
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
