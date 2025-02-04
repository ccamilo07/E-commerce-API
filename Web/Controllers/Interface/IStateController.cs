using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IStateController
    {
        Task<ActionResult<IEnumerable<State>>> GetAll();
        Task<ActionResult<State>> GetById(int id);
        Task<ActionResult<State>> Save([FromBody] State state);
        Task<IActionResult> Update([FromBody] State state);
        Task<IActionResult> Delete(int id);
    }

}
