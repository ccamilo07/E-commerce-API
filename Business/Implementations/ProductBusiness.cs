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
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductData _productData;

        public ProductBusiness(IProductData productData)
        {
            _productData = productData;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                return await _productData.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (ProductBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task<Product> GetById(int id)
        {
            try
            {
                return await _productData.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (ProductBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task<Product> Save(Product product)
        {
            try
            {
                if (string.IsNullOrEmpty(product.Name))
                    throw new Exception("El nombre del producto no puede estar vacío.");

                return await _productData.Save(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (ProductBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task Update(Product product)
        {
            try
            {
                await _productData.Update(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (ProductBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _productData.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (ProductBusiness): {ex.Message}");
                throw;
            }
        }
    }

}
