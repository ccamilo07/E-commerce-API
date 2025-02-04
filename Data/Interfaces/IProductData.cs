using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IProductData
    {
        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns>
        /// IEnumerable<State>
        /// </returns>
        Task<IEnumerable<Product>> GetAll();

        /// <summary>
        /// Obtiene el id del producto
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// State
        /// </returns>
        Task<Product> GetById(int id);

        /// <summary>
        /// Actualiza el producto
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// </returns>
        Task Update(Product product);

        /// <summary>
        /// Guarda la informacion actualizada
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// State
        /// </returns>
        Task<Product> Save(Product product);

        /// <summary>
        /// Elimina Estado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);
    }
}
