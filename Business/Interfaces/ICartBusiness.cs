using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models;

namespace Business.Interfaces
{
    public interface ICartBusiness
    {
        Task<IEnumerable<Cart>> GetAll();
        Task<Cart> GetById(int id);
        Task<Cart> Save(Cart cart);
        Task Update(Cart cart);
        Task Delete(int id);
    }
}
