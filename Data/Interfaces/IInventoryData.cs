using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IInventoryData
    {
        Task<IEnumerable<Inventory>> GetAll();
        Task<Inventory> GetById(int id);
        Task update(Inventory inventory);
        Task<Inventory> Save(Inventory inventory);
        Task Delete(int id);
    }
}
