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
    public class CartBusiness : ICartBusiness
    {
        private readonly ICartData _cartData;

        public CartBusiness(ICartData cartData)
        {
            _cartData = cartData;
        }
        public async Task<IEnumerable<Cart>> GetAll()
        {
            try
            {
                return await _cartData.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (CartBusiness): {ex.Message}");
                throw;
            }
        }
        public async Task<Cart> GetById(int id)
        {
            try
            {
                return await _cartData.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (CartBusiness): {ex.Message}");
                throw;
            }
        }
        public async Task<Cart> Save(Cart cart)
        {
            try
            {
                if (cart == null || cart.Items.Count == 0)
                    throw new Exception("El carrito no puede estar vacío.");

                return await _cartData.Save(cart);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (CartBusiness): {ex.Message}");
                throw;
            }
        }
        public async Task Update(Cart cart)
        {
            try
            {
                await _cartData.Update(cart);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (CartBusiness): {ex.Message}");
                throw;
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                await _cartData.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (CartBusiness): {ex.Message}");
                throw;
            }
        }
    }
}
