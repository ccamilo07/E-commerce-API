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
    public class CountryBusiness : ICountryBusiness
    {
        private readonly ICountryData _countryData;

        public CountryBusiness(ICountryData countryData)
        {
            _countryData = countryData;
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            try
            {
                return await _countryData.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (CountryBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task<Country> GetById(int id)
        {
            try
            {
                return await _countryData.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (CountryBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task<Country> Save(Country country)
        {
            try
            {
                if (string.IsNullOrEmpty(country.Name))
                    throw new Exception("El nombre del país no puede estar vacío.");

                return await _countryData.Save(country);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (CountryBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task Update(Country country)
        {
            try
            {
                await _countryData.Update(country);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (CountryBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _countryData.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (CountryBusiness): {ex.Message}");
                throw;
            }
        }
    }

}
