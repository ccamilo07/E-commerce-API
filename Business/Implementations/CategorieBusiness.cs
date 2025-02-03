using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Models;

namespace Business.Implementations
{
    public class CategorieBusiness : ICategorieBusiness
    {
        private readonly ICategorieData _categorieData;

        public CategorieBusiness(ICategorieData categorieData)
        {
            _categorieData = categorieData;
        }

        public async Task<IEnumerable<Categorie>> GetAll()
        {
            try
            {
                return await _categorieData.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (CategorieBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task<Categorie> GetById(int id)
        {
            try
            {
                return await _categorieData.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (CategorieBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task<Categorie> Save(Categorie categorie)
        {
            try
            {
                if (string.IsNullOrEmpty(categorie.Name))
                    throw new Exception("El nombre de la categoría no puede estar vacío.");

                return await _categorieData.Save(categorie);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (CategorieBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task Update(Categorie categorie)
        {
            try
            {
                await _categorieData.Update(categorie);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (CategorieBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _categorieData.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (CategorieBusiness): {ex.Message}");
                throw;
            }
        }
    }

}
