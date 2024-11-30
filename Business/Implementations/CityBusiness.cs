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
    public class CityBusiness: ICityBusiness 
    {
        private readonly ICityData cityData;

        public CityBusiness (ICityData cityData)
        {
            this.cityData = cityData;
        }
        public async Task<IEnumerable<City>> GetAll()
        {
            try
            {
                IEnumerable<City> cities = await cityData.Getall();
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
                City city = await cityData.GetById(id);
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
                return await cityData.Save(city);
               
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
                await cityData.Update(city);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al Actulizar City {ex.Message}");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await cityData.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar City{ex.Message}");
            }

    }
}
