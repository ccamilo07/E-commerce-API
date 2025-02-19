using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implemetation
{
    [Route("api/country")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryBusiness _countryBusiness;

        public CountryController(ICountryBusiness countryBusiness)
        {
            _countryBusiness = countryBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetAll()
        {
            try
            {
                var countries = await _countryBusiness.GetAll();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (CountryController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("country/{id}")]
        public async Task<ActionResult<Country>> GetById(int id)
        {
            try
            {
                var country = await _countryBusiness.GetById(id);
                if (country == null) return NotFound("País no encontrado.");
                return Ok(country);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (CountryController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Country>> Save([FromBody] Country country)
        {
            try
            {
                var newCountry = await _countryBusiness.Save(country);
                return CreatedAtAction(nameof(GetById), new { id = newCountry.Id }, newCountry);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (CountryController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Country country)
        {
            try
            {
                await _countryBusiness.Update(country);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (CountryController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _countryBusiness.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (CountryController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }

}
