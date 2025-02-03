using Business.Interfaces;
using Data.Interfaces;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace Business.Implementations
{
    public class CityBusiness : ICityBusiness
    {
        private readonly ICityData _cityData;

        public CityBusiness(ICityData cityData)
        {
            _cityData = cityData;
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            try
            {
                return await _cityData.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (CityBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task<City> GetById(int id)
        {
            try
            {
                return await _cityData.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (CityBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task<City> Save(City city)
        {
            try
            {
                if (string.IsNullOrEmpty(city.Name))
                    throw new Exception("El nombre de la ciudad no puede estar vacío.");

                return await _cityData.Save(city);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (CityBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task Update(City city)
        {
            try
            {
                await _cityData.Update(city);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (CityBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _cityData.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (CityBusiness): {ex.Message}");
                throw;
            }
        }
    }
}
