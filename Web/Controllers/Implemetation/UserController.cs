using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implemetation
{
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            try
            {
                var users = await _userBusiness.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (UserController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            try
            {
                var user = await _userBusiness.GetById(id);
                if (user == null) return NotFound("Usuario no encontrado.");
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (UserController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> Save([FromBody] User user)
        {
            try
            {
                var newUser = await _userBusiness.Save(user);
                return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (UserController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            try
            {
                await _userBusiness.Update(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (UserController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _userBusiness.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (UserController): {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }

}
