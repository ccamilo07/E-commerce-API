using Data.Interfaces;
using Entity.Context;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace Data.Implementations
{
    public class CityData : ICityData
    {
        protected readonly ApplicationDBContext _context;
        
        public CityData (ApplicationDBContext context) 
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            try
            {
                await _context.Set<City>().Where(i => i.Id == id).ExecuteDeleteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar City {ex.Message}");
            }
        }

        public async Task<IEnumerable<City>> Getall()
        {
            try
            {
                IEnumerable<City> cities = await _context.Set<City>().ToListAsync();
                return cities;
            } 
            catch (Exception ex) 
            {
                Console.WriteLine($"Error al consultar City {ex.Message}");
                throw;
            }
        }

        public async Task<City> GetById(int id)
        {
            try
            {
                City city = await _context.Set<City>().FindAsync(id);
                return city;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consulta Id City {ex.Message}");
                throw;
            }
        }

        public async Task<City> Save(City city)
        {
            try
            {
                _context.Set<City>().Add(city);
                await _context.SaveChangesAsync();
                return city;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar City {ex.Message}");
                throw;
            }
        }

        public async Task Update(City city)
        {
            try
            {
                _context.Entry(city).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al Actulizar City {ex.Message}");
                throw;
            }
        }
    }
}
