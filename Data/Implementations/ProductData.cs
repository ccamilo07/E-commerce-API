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
    public class ProductData : IProductData
    {
        private readonly ApplicationDBContext _context;

        public ProductData(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                return await _context.Set<Product>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (ProductData): {ex.Message}");
                throw;
            }
        }

        public async Task<Product> GetById(int id)
        {
            try
            {
                return await _context.Set<Product>().FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (ProductData): {ex.Message}");
                throw;
            }
        }

        public async Task<Product> Save(Product product)
        {
            try
            {
                _context.Set<Product>().Add(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (ProductData): {ex.Message}");
                throw;
            }
        }

        public async Task Update(Product product)
        {
            try
            {
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (ProductData): {ex.Message}");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var product = await _context.Set<Product>().FindAsync(id);
                if (product != null)
                {
                    _context.Set<Product>().Remove(product);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (ProductData): {ex.Message}");
                throw;
            }
        }
    }

}
