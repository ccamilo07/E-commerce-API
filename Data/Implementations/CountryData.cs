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
    public class CountryData : ICountryData
    {
        private readonly ApplicationDBContext _context;

        public CountryData(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            try
            {
                return await _context.Set<Country>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (CountryData): {ex.Message}");
                throw;
            }
        }

        public async Task<Country> GetById(int id)
        {
            try
            {
                return await _context.Set<Country>().FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (CountryData): {ex.Message}");
                throw;
            }
        }
        public async Task<Country> Save(Country country)
        {
            try
            {
                _context.Set<Country>().Add(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (CountryData): {ex.Message}");
                throw;
            }
        }

        public async Task Update(Country country)
        {
            try
            {
                _context.Entry(country).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (CountryData): {ex.Message}");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var country = await _context.Set<Country>().FindAsync(id);
                if (country != null)
                {
                    _context.Set<Country>().Remove(country);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (CountryData): {ex.Message}");
                throw;
            }
        }
    }

}
