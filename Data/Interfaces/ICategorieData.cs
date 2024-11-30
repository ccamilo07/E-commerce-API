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
        Task<IEnumerable<Categoria>> GetAll();
        Task<Categoria> GetById(int id);
        Task update(Categoria categoria);
        Task<Categoria> Save(Categoria categoria);
    }
}
