using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mysqlx.Crud;

namespace Business.Interfaces
{
    public interface IOrdersBusiness
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(int id);
        Task<Order> Save(Order order);
        Task Update(Order order);
        Task Delete(int id);
    }
}
