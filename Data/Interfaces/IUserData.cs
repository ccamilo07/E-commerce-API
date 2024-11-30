using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserData
    {
        Task<Usuario> GetById(int id);
        Task Update (Usuario usuario);
        Task<Usuario> Save (Usuario usuario);
        Task Delete (int id);
    }
}
