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
    public class StateBusiness : IStateBusiness
    {
        private readonly IStateData _stateData;

        public StateBusiness(IStateData stateData)
        {
            _stateData = stateData;
        }

        public async Task<IEnumerable<State>> GetAll()
        {
            try
            {
                return await _stateData.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAll (StateBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task<State> GetById(int id)
        {
            try
            {
                return await _stateData.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById (StateBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task<State> Save(State state)
        {
            try
            {
                if (string.IsNullOrEmpty(state.Name))
                    throw new Exception("El nombre del estado no puede estar vacío.");

                return await _stateData.Save(state);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Save (StateBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task Update(State state)
        {
            try
            {
                await _stateData.Update(state);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update (StateBusiness): {ex.Message}");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _stateData.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (StateBusiness): {ex.Message}");
                throw;
            }
        }
    }

}
