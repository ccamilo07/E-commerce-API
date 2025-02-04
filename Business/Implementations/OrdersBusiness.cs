using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Models;
using Mysqlx.Crud;

namespace Business.Implementations
{
    public class OrdersBusiness : IOrdersBusiness
    {
        private readonly IOrdersData _ordersData;

        public OrdersBusiness(IOrdersData ordersData)
        {
            _ordersData = ordersData;
        }

        public async Task<IEnumerable<Orders>> GetAll()
        {
            try
            {
                return await _ordersData.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (OrdersBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task<Orders> GetById(int id)
        {
            try
            {
                return await _ordersData.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (OrdersBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task<Orders> Save(Orders orders)
        {
            try
            {
                if (orders.TotalAmount <= 0)
                    throw new Exception("El total del pedido debe ser mayor a cero.");

                return await _ordersData.Save(orders);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (OrdersBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task Update(Orders orders)
        {
            try
            {
                await _ordersData.Update(orders);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (OrdersBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _ordersData.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (OrdersBusiness): {ex.Message}");
                throw;
            }
        }
    }

}
