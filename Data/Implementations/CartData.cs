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
    public class CartData : ICartData
    {
        private readonly ApplicationDBContext _context;

        public CartData(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cart>> GetAll()
        {
            try
            {
                return await _context.Set<Cart>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (CartData): {ex.Message}");
                throw;
            }
        }
        public async Task<Cart> GetById(int id)
        {
            try
            {
                return await _context.Set<Cart>()
                    .Include(c => c.User)
                    .Include(c => c.Product)
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (CartData): {ex.Message}");
                throw;
            }
        }
        public async Task<Cart> Save(Cart cart)
        {
            try
            {
                _context.Set<Cart>().Add(cart);
                await _context.SaveChangesAsync();
                return cart;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (CartData): {ex.Message}");
                throw;
            }
        }
        public async Task Update(Cart cart)
        {
            try
            {
                _context.Entry(cart).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (CartData): {ex.Message}");
                throw;
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                var cart = await _context.Set<Cart>().FindAsync(id);
                if (cart != null)
                {
                    _context.Set<Cart>().Remove(cart);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (CartData): {ex.Message}");
                throw;
            }
        }
    }

}
