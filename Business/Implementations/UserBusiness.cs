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
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserData _userData;

        public UserBusiness(IUserData userData)
        {
            _userData = userData;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await _userData.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (UserBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task<User> GetById(int id)
        {
            try
            {
                return await _userData.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (UserBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task<User> Save(User user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email))
                    throw new Exception("El nombre y el email del usuario no pueden estar vacíos.");

                return await _userData.Save(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (UserBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task Update(User user)
        {
            try
            {
                await _userData.Update(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (UserBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _userData.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (UserBusiness): {ex.Message}");
                throw;
            }
        }
    }

}
