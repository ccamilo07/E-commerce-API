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
    public class UserData : IUserData
    {
        private readonly ApplicationDBContext _context;

        public UserData(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await _context.Set<User>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (UserData): {ex.Message}");
                throw;
            }
        }

        public async Task<User> GetById(int id)
        {
            try
            {
                return await _context.Set<User>().FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (UserData): {ex.Message}");
                throw;
            }
        }

        public async Task<User> Save(User user)
        {
            try
            {
                _context.Set<User>().Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (UserData): {ex.Message}");
                throw;
            }
        }

        public async Task Update(User user)
        {
            try
            {
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (UserData): {ex.Message}");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var user = await _context.Set<User>().FindAsync(id);
                if (user != null)
                {
                    _context.Set<User>().Remove(user);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (UserData): {ex.Message}");
                throw;
            }
        }
    }

}
