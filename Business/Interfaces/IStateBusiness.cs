using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models;

namespace Business.Interfaces
{
    public interface IStateBusiness
    {
        Task<IEnumerable<State>> GetAll();
        Task<State> GetById(int id);
        Task<State> Save(State state);
        Task Update(State state);
        Task Delete(int id);
    }

}
