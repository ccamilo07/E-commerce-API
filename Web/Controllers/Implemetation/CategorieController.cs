using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implemetation
{
    public class CategorieController : ControllerBase
    {
        private readonly ICategorieBusiness _categorieBusiness;

        public CategorieController(ICategorieBusiness categorieBusiness)
        {
            _categorieBusiness = categorieBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorie>>> GetAll()
        {
            try
            {
                var categorie = await _categorieBusiness.GetAll();
                return Ok(categorie);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (CategorieController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Categorie>> GetById(int id)
        {
            try
            {
                var categorie = await _categorieBusiness.GetById(id);
                if (categorie == null) return NotFound("Categoria no encontrada.");
                return Ok(categorie);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (CategorieController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Categorie>> Save([FromBody] Categorie categorie)
        {
            try
            {
                var newCategorie = await _categorieBusiness.Save(categorie);
                return CreatedAtAction(nameof(GetById), new { id = newCategorie.Id }, newCategorie);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (CategorieController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Categorie categorie)
        {
            try
            {
                await _categorieBusiness.Update(categorie);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (CategorieController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _categorieBusiness.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (CategorieController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }
}
