using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vestigia.Domain.Entities;
using Vestigia.Domain.Interfaces;
using Vestigia.Infrastructure.Data;

namespace Vestigia.Infrastructure.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly VestigiaContext _context;
        public ContaRepository(VestigiaContext context)
        {
            _context = context;
        }

        public Task<Conta> GetByIdAsync(Guid id)
        {
            return _context.Contas.FindAsync(id).AsTask();
        }

        public Task<List<Conta>> GetAllAsync(Guid idUsuario)
        {
            return Task.FromResult(_context.Contas.Where(c => c.IdUsuario == idUsuario).ToList());
        }

        public Task AddAsync(Conta conta)
        {
            _context.Contas.Add(conta);
            return _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Conta conta)
        {
            _context.Contas.Update(conta);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            var conta = _context.Contas.FirstOrDefaultAsync(c => c.Id == id);
            _context.Contas.Remove(conta.Result);
            return _context.SaveChangesAsync();
        }

        public Task<Conta> GetByNumeroAsync(string numero)
        {
            return _context.Contas.FirstOrDefaultAsync(c => c.NumeroConta == numero);
        }
    }
}