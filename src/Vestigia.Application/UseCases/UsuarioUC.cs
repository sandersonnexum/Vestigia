using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Cache;
using System.Threading.Tasks;
using Vestigia.Application.DTOs;
using Vestigia.Domain.Entities;
using Vestigia.Domain.Interfaces;

namespace Vestigia.Application.UseCases.UsuarioUC
{
    public class UsuarioUC
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioUC(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Task<Usuario> GetById(Guid id)
        {
            return _usuarioRepository.GetByIdAsync(id);
        }

        public Task<Usuario> GetByEmail(string email)
        {
            return _usuarioRepository.GetByEmailAsync(email);
        }

        public Task<Usuario> GetByUsername(string username)
        {
            return _usuarioRepository.GetByUsernameAsync(username);
        }

        public Task<List<Usuario>> GetAll()
        {
            return _usuarioRepository.GetAllAsync();
        }

        public async Task Add(UsuarioDTO.RequestAddUpdate usuario)
        {
            var newUsuario = new Usuario(
                usuario.Nome,
                usuario.Email,
                usuario.Senha,
                usuario.Username,
                usuario.Ativo,
                usuario.DataCriacao
            );
            await _usuarioRepository.AddAsync(newUsuario);
        }

        public async Task Update(Guid id, UsuarioDTO.RequestAddUpdate usuario)
        {
            var existingUsuario = await _usuarioRepository.GetByIdAsync(id);
            if (existingUsuario == null)
            {
                throw new Exception($"Usuario with id {id} not found");
            }
            existingUsuario = new Usuario(
                usuario.Nome,
                usuario.Email,
                usuario.Senha,
                usuario.Username,
                usuario.Ativo,
                usuario.DataCriacao
            );
            await _usuarioRepository.UpdateAsync(existingUsuario);
        }

        public async Task Delete(Guid id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }
    }
}