using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Entity.Context;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class CategorieData : ICategorieData
    {
        private readonly ApplicationDBContext _context;

        public CategorieData(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categorie>> GetAll()
        {
            try
            {
                return await _context.Set<Categorie>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (CategorieData): {ex.Message}");
                throw;
            }
        }

        public async Task<Categorie> GetById(int id)
        {
            try
            {
                return await _context.Set<Categorie>().FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (CategorieData): {ex.Message}");
                throw;
            }
        }

        public async Task<Categorie> Save(Categorie categorie)
        {
            try
            {
                _context.Set<Categorie>().Add(categorie);
                await _context.SaveChangesAsync();
                return categorie;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (CategorieData): {ex.Message}");
                throw;
            }
        }

        public async Task Update(Categorie categorie)
        {
            try
            {
                _context.Entry(categorie).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (CategorieData): {ex.Message}");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var categorie = await _context.Set<Categorie>().FindAsync(id);
                if (categorie != null)
                {
                    _context.Set<Categorie>().Remove(categorie);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (CategorieData): {ex.Message}");
                throw;
            }
        }
    }

}
