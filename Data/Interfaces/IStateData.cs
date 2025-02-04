using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IStateData
    {
        /// <summary>
        /// Obtiene todas las ciudades
        /// </summary>
        /// <returns>
        /// IEnumerable<State>
        /// </returns>
        Task<IEnumerable<State>> GetAll();

        /// <summary>
        /// Obtiene el id de la ciudad
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// State
        /// </returns>
        Task<State> GetById(int id);

        /// <summary>
        /// Actualiza la ciudad
        /// </summary>
        /// <param name="state"></param>
        /// <returns>
        /// </returns>
        Task Update(State state);

        /// <summary>
        /// Guarda la informacion actualizada
        /// </summary>
        /// <param name="state"></param>
        /// <returns>
        /// State
        /// </returns>
        Task<State> Save(State state);

        /// <summary>
        /// Elimina Estado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);
    }
}
