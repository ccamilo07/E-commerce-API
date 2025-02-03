using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models;

namespace Business.Interfaces
{
    public interface ICategorieBusiness
    {
        Task<IEnumerable<Categorie>> GetAll();
        Task<Categorie> GetById(int id);
        Task<Categorie> Save(Categorie categorie);
        Task Update(Categorie categorie);
        Task Delete(int id);
    }

}
