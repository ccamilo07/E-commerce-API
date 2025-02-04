using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implemetation
{
    public class CartController : ControllerBase
    {
        private readonly ICartBusiness _cartBusiness;

        public CartController(ICartBusiness cartBusiness)
        {
            _cartBusiness = cartBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetAll()
        {
            try
            {
                var carts = await _cartBusiness.GetAll();
                return Ok(carts);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (CartController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetById(int id)
        {
            try
            {
                var cart = await _cartBusiness.GetById(id);
                if (cart == null) return NotFound("Carrito no encontrado.");
                return Ok(cart);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (CartController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Cart>> Save([FromBody] Cart cart)
        {
            try
            {
                var newCart = await _cartBusiness.Save(cart);
                return CreatedAtAction(nameof(GetById), new { id = newCart.Id }, newCart);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (CartController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Cart cart)
        {
            try
            {
                await _cartBusiness.Update(cart);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (CartController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _cartBusiness.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (CartController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }

}
