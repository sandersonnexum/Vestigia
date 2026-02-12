using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Domain.Entities;

namespace Vestigia.Domain.Interfaces
{
    public interface IContaRepository
    {
        Task<Conta> GetByIdAsync(Guid id);
        Task<List<Conta>> GetAllAsync();
        Task AddAsync(Conta conta);
        Task UpdateAsync(Conta conta);
        Task DeleteAsync(Guid id);
        
    }
}