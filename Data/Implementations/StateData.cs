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
        public async Task<IEnumerable<State>> Getall()
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
                var sql = @"Select
                                Id,
                          from State
                            where id=@stateId";
                State state = await _dbContext.Set<State>().FromSqlRaw(sql, stateId).FirstOrDefaultAsync();
                return state;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error al consultar State {ex.Message}");
                throw;
            }
        }
    }
}
