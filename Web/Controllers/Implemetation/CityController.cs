using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implemetation
{
    public class CityController : ControllerBase
    {
        private readonly ICityBusiness _cityBusiness;

        public CityController(ICityBusiness cityBusiness)
        {
            _cityBusiness = cityBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetAll()
        {
            try
            {
                var cities = await _cityBusiness.GetAll();
                return Ok(cities);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (CityController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetById(int id)
        {
            try
            {
                var city = await _cityBusiness.GetById(id);
                if (city == null) return NotFound("Ciudad no encontrada.");
                return Ok(city);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (CityController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<City>> Save([FromBody] City city)
        {
            try
            {
                var newCity = await _cityBusiness.Save(city);
                return CreatedAtAction(nameof(GetById), new { id = newCity.Id }, newCity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (CityController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] City city)
        {
            try
            {
                await _cityBusiness.Update(city);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (CityController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _cityBusiness.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (CityController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }

}
