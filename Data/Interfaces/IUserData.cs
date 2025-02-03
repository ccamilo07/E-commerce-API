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
        Task<User> GetById(int id);
        Task Update (User usuario);
        Task<User> Save (User user);
        Task Delete (int id);
    }
}
