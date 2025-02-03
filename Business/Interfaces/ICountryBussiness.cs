using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models;

namespace Business.Interfaces
{
    public interface ICountryBusiness
    {
        Task<IEnumerable<Country>> GetAll();
        Task<Country> GetById(int id);
        Task<Country> Save(Country country);
        Task Update(Country country);
        Task Delete(int id);
    }

}
