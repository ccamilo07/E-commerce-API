using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface ICategorieController
    {
        Task<ActionResult<IEnumerable<Categorie>>> GetAll();
        Task<ActionResult<Categorie>> GetById(int id);
        Task<ActionResult<Categorie>> Save([FromBody] Categorie categorie);
        Task<IActionResult> Update([FromBody] Categorie categorie);
        Task<IActionResult> Delete(int id);
    }

}
