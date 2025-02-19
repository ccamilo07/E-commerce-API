using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implemetation
{
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductBusiness _productBusiness;

        public ProductController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            try
            {
                var products = await _productBusiness.GetAll();
                return Ok(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (ProductController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("product/{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            try
            {
                var product = await _productBusiness.GetById(id);
                if (product == null) return NotFound("Producto no encontrado.");
                return Ok(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (ProductController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Save([FromBody] Product product)
        {
            try
            {
                var newProduct = await _productBusiness.Save(product);
                return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (ProductController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            try
            {
                await _productBusiness.Update(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (ProductController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productBusiness.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (ProductController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }

}
