using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICartData
    {
        Task<Cart> GetById (int id);
        Task Update (Cart cart);
        Task<Cart> Save (Cart cart);
        Task Delete (int id);
    }
}
