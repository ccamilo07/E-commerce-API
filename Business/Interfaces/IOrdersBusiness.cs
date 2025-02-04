using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models;
using Mysqlx.Crud;

namespace Business.Interfaces
{
    public interface IOrdersBusiness
    {
        Task<IEnumerable<Orders>> GetAll();
        Task<Orders> GetById(int id);
        Task<Orders> Save(Orders orders);
        Task Update(Orders orders);
        Task Delete(int id);
    }
}
