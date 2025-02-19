using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implemetation
{
    [Route("api/products")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryBusiness _inventoryBusiness;

        public InventoryController(IInventoryBusiness inventoryBusiness)
        {
            _inventoryBusiness = inventoryBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetAll()
        {
            try
            {
                var inventories = await _inventoryBusiness.GetAll();
                return Ok(inventories);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (InventoryController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("inventory/{id}")]
        public async Task<ActionResult<Inventory>> GetById(int id)
        {
            try
            {
                var inventory = await _inventoryBusiness.GetById(id);
                if (inventory == null) return NotFound("Inventario no encontrado.");
                return Ok(inventory);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (InventoryController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Inventory>> Save([FromBody] Inventory inventory)
        {
            try
            {
                var newInventory = await _inventoryBusiness.Save(inventory);
                return CreatedAtAction(nameof(GetById), new { id = newInventory.Id }, newInventory);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (InventoryController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Inventory inventory)
        {
            try
            {
                await _inventoryBusiness.Update(inventory);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (InventoryController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _inventoryBusiness.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (InventoryController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }

}
