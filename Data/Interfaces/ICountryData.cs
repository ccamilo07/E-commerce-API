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
        Task<IEnumerable<Country>> Getall();
        Task<Country> GetById(int id);
        Task Update(Country country);
        Task<State> Save(Country country);
        Task Delete(int id);
    }
}
