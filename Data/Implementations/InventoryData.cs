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
    public class InventoryData : IInventoryData
    {
        private readonly ApplicationDBContext _context;

        public InventoryData(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inventory>> GetAll()
        {
            try
            {
                return await _context.Set<Inventory>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (InventoryData): {ex.Message}");
                throw;
            }
        }

        public async Task<Inventory> GetById(int id)
        {
            try
            {
                return await _context.Set<Inventory>().FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (InventoryData): {ex.Message}");
                throw;
            }
        }

        public async Task<Inventory> Save(Inventory inventory)
        {
            try
            {
                _context.Set<Inventory>().Add(inventory);
                await _context.SaveChangesAsync();
                return inventory;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (InventoryData): {ex.Message}");
                throw;
            }
        }

        public async Task Update(Inventory inventory)
        {
            try
            {
                _context.Entry(inventory).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (InventoryData): {ex.Message}");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var inventory = await _context.Set<Inventory>().FindAsync(id);
                if (inventory != null)
                {
                    _context.Set<Inventory>().Remove(inventory);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (InventoryData): {ex.Message}");
                throw;
            }
        }
    }

}
