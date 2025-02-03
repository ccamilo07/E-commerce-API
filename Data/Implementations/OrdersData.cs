using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Entity.Context;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;

namespace Data.Implementations
{
    public class OrdersData : IOrdersData
    {
        private readonly ApplicationDBContext _context;

        public OrdersData(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Orders>> GetAll()
        {
            try
            {
                return await _context.Set<Orders>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (OrdersData): {ex.Message}");
                throw;
            }
        }

        public async Task<Orders> GetById(int id)
        {
            try
            {
                return await _context.Set<Orders>().FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (OrdersData): {ex.Message}");
                throw;
            }
        }

        public async Task<Orders> Save(Orders orders)
        {
            try
            {
                _context.Set<Orders>().Add(orders);
                await _context.SaveChangesAsync();
                return orders;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (OrdersData): {ex.Message}");
                throw;
            }
        }

        public async Task Update(Orders orders)
        {
            try
            {
                _context.Entry(orders).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (OrdersData): {ex.Message}");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var orders = await _context.Set<Orders>().FindAsync(id);
                if (orders != null)
                {
                    _context.Set<Order>().Remove(orders);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (OrdersData): {ex.Message}");
                throw;
            }
        }

    }

}
