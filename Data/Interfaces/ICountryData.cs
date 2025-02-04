using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICountryData
    {
        Task<IEnumerable<Country>> GetAll();
        Task<Country> GetById(int id);
        Task Update(Country country);
        Task<Country> Save(Country country);
        Task Delete(int id);
    }
}
