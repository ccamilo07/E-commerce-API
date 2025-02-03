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
    public class InventoryBusiness : IInventoryBusiness
    {
        private readonly IInventoryData _inventoryData;

        public InventoryBusiness(IInventoryData inventoryData)
        {
            _inventoryData = inventoryData;
        }

        public async Task<IEnumerable<Inventory>> GetAll()
        {
            try
            {
                return await _inventoryData.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (InventoryBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task<Inventory> GetById(int id)
        {
            try
            {
                return await _inventoryData.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (InventoryBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task<Inventory> Save(Inventory inventory)
        {
            try
            {
                if (inventory.Stock < 0)
                    throw new Exception("El stock no puede ser negativo.");

                return await _inventoryData.Save(inventory);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (InventoryBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task Update(Inventory inventory)
        {
            try
            {
                await _inventoryData.Update(inventory);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (InventoryBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _inventoryData.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (InventoryBusiness): {ex.Message}");
                throw;
            }
        }
    }

}
