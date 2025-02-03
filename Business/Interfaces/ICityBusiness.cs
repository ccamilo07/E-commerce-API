using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICityBusiness
    {
        Task<IEnumerable<City>> GetAll();
        Task<City> GetById(int id);
        Task<City> Save(City city);
        Task Update(City city);
        Task Delete(int id);
    }
}
