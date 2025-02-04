using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICategorieData
    {
        Task<IEnumerable<Categorie>> GetAll();
        Task<Categorie> GetById(int id);
        Task Update(Categorie categorie);
        Task<Categorie> Save(Categorie categorie);
        
    }
}
