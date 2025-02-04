using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implemetation
{
    public class StateController : ControllerBase
    {
        private readonly IStateBusiness _stateBusiness;

        public StateController(IStateBusiness stateBusiness)
        {
            _stateBusiness = stateBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> GetAll()
        {
            try
            {
                var states = await _stateBusiness.GetAll();
                return Ok(states);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (StateController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetById(int id)
        {
            try
            {
                var state = await _stateBusiness.GetById(id);
                if (state == null) return NotFound("Estado no encontrado.");
                return Ok(state);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (StateController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<State>> Save([FromBody] State state)
        {
            try
            {
                var newState = await _stateBusiness.Save(state);
                return CreatedAtAction(nameof(GetById), new { id = newState.Id }, newState);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (StateController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] State state)
        {
            try
            {
                await _stateBusiness.Update(state);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (StateController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _stateBusiness.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (StateController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }

}
