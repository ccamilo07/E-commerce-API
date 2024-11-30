using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICityData
    {
        /// <summary>
        /// Obtiene todas las ciudades
        /// </summary>
        /// <returns>
        /// IEnumerable<City>
        /// </returns>
        Task<IEnumerable<City>> Getall();

        /// <summary>
        /// Obtiene el id de la ciudad
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// City
        /// </returns>
        Task<City> GetById(int id);

        /// <summary>
        /// Actualiza la ciudad
        /// </summary>
        /// <param name="city"></param>
        /// <returns>
        /// </returns>
        Task Update (City city);

        /// <summary>
        /// Guarda la informacion actualizada
        /// </summary>
        /// <param name="city"></param>
        /// <returns>
        /// City
        /// </returns>
        Task <City> Save (City city);

        /// <summary>
        /// Elimina Ciudad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete (int id);
    }
}
