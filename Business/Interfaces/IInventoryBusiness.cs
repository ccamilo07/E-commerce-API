using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models;

namespace Business.Interfaces
{
    public interface IInventoryBusiness
    {
        Task<IEnumerable<Inventory>> GetAll();
        Task<Inventory> GetById(int id);
        Task<Inventory> Save(Inventory inventory);
        Task Update(Inventory inventory);
        Task Delete(int id);
    }
}
