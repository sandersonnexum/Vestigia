using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Application.DTOs;
using Vestigia.Domain.Entities;
using Vestigia.Domain.Interfaces;
using Vestigia.Domain.ValueObjects;
using Vestigia.Infrastructure.Data;

namespace Vestigia.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly VestigiaContext _context;

        public UsuarioRepository(VestigiaContext context)
        {
            _context = context;
        }

        public Task AddAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Guid id)
        {

            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                return _context.SaveChangesAsync();
            }
            return Task.CompletedTask;
        }

        public Task<List<Usuario>> GetAllAsync()
        {
            return Task.FromResult(_context.Usuarios.ToList());
        }

        public Task<Usuario> GetByEmailAsync(string email)
        {
            var email1 = new Email(email);
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email1);
            return Task.FromResult(usuario);
        }

        public Task<Usuario> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_context.Usuarios.Find(id));
        }

        public Task<Usuario> GetByUsernameAsync(string username)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Username == username);
            return Task.FromResult(usuario);
        }

        public Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            return _context.SaveChangesAsync();
        }
    }
}