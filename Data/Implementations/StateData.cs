using Data.Interfaces;
using Entity.Context;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class StateData : IStateData
    {
        private readonly ApplicationDBContext _dbContext;
        public StateData(ApplicationDBContext context)
        {
            _dbContext = context;
        }
        public async Task<IEnumerable<State>> GetAll()
        {
            try
            {
                var sql = @"select 
                                Id,
                                Name,
                                Active,
                                CountryId
                            from State";
                IEnumerable<State> states = await _dbContext.Set<State>().FromSqlRaw(sql).ToListAsync();
                return states;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consultar State {ex.Message}");
                throw;
            }

        }
        public async Task<State> GetById(int stateId)
        {
            try
            {
                var sql = @"Select Id, Name, Active, CountryId from State where Id = {0}";
                State state = await _dbContext.Set<State>().FromSqlRaw(sql, stateId).FirstOrDefaultAsync();
                return state;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error al consultar State {ex.Message}");
                throw;
            }
        }
        public async Task<State> Save(State state)
        {
            try
            {
                _dbContext.Set<State>().Add(state);
                await _dbContext.SaveChangesAsync ();
                return state;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (StateData): {ex.Message}");
                throw;
            }
        }

        public async Task Update(State state)
        {
            try
            {
                _dbContext.Entry(state).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (StateData): {ex.Message}");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var state = await _dbContext.Set<State>().FindAsync(id);
                if (state != null)
                {
                    _dbContext.Set<State>().Remove(state);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (StateData): {ex.Message}");
                throw;
            }
        }
    }
}
