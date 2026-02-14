using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Cache;
using System.Threading.Tasks;
using Vestigia.Application.DTOs;
using Vestigia.Domain.Entities;
using Vestigia.Domain.Interfaces;
using Vestigia.Domain.ValueObjects;

namespace Vestigia.Application.UseCases.UsuarioUC
{
    public class UsuarioUC
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioUC(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<dynamic> GetById(Guid id)
        {
            var usuario = _usuarioRepository.GetByIdAsync(id);
            var formatUser = new Usuario(
                usuario.Result.Id,
               usuario.Result.Nome,
               usuario.Result.Email,
               usuario.Result.SenhaHash,
               usuario.Result.Username,
               usuario.Result.Ativo,
               usuario.Result.DataCriacao
           );
            var error = new ErroDTO(
                mensagem: usuario == null ? "Usuario not found" : "Success",
                detalhes: usuario == null ? $"No user found with ID {id}" : "Usuario found successfully",
                codigo: usuario == null ? 404 : 200
            );
            return new UsuarioDTO.ResponseUsuario
            {
                Usuario = formatUser,
                Erro = error
            };
        }

        public async Task<UsuarioDTO.ResponseUsuario> GetByEmail(string email)
        {
            var usuario = _usuarioRepository.GetByEmailAsync(email);
            var formatUser = new Usuario(
               usuario.Result.Id,
               usuario.Result.Nome,
               usuario.Result.Email,
               usuario.Result.SenhaHash,
               usuario.Result.Username,
               usuario.Result.Ativo,
               usuario.Result.DataCriacao
           );
            var error = new ErroDTO(
                mensagem: usuario == null ? "Usuario not found" : "Success",
                detalhes: usuario == null ? $"No user found with email {email}" : "Usuario found successfully",
                codigo: usuario == null ? 404 : 200
            );
            return new UsuarioDTO.ResponseUsuario
            {
                Usuario = formatUser,
                Erro = error
            };
        }

        public async Task<UsuarioDTO.ResponseUsuario> GetByUsername(string username)
        {
            var usuario = _usuarioRepository.GetByUsernameAsync(username);
            var formatUser = new Usuario(
                usuario.Result.Id,
               usuario.Result.Nome,
               usuario.Result.Email,
               usuario.Result.SenhaHash,
               usuario.Result.Username,
               usuario.Result.Ativo,
               usuario.Result.DataCriacao
           );
            var error = new ErroDTO(
                mensagem: usuario == null ? "Usuario not found" : "Success",
                detalhes: usuario == null ? $"No user found with username {username}" : "Usuario found successfully",
                codigo: usuario == null ? 404 : 200
            );
            return new UsuarioDTO.ResponseUsuario
            {
                Usuario = formatUser,
                Erro = error
            };
        }

        public async Task<UsuarioDTO.ResponseGetAllUsuarios> GetAll()
        {
            var usuarios = _usuarioRepository.GetAllAsync();
            var listUser = new List<Usuario>();
            foreach (var usuario in usuarios.Result)
            {
                var formatUser = new Usuario(
                    usuario.Id,
                    usuario.Nome,
                    usuario.Email,
                    usuario.SenhaHash,
                    usuario.Username,
                    usuario.Ativo,
                    usuario.DataCriacao
                );
                listUser.Add(formatUser);
            }
            var error = new ErroDTO(
                mensagem: usuarios == null ? "Usuarios not found" : "Success",
                detalhes: usuarios == null ? "No users found" : "Usuarios retrieved successfully",
                codigo: usuarios == null ? 404 : 200
            );
            return new UsuarioDTO.ResponseGetAllUsuarios
            {
                Usuarios = listUser,
                Erro = error
            };
        }

        public async Task<UsuarioDTO.ResponseUsuario> Add(UsuarioDTO.RequestAddUpdateUsuario usuario)
        {
            var nome = new Nome(usuario.Nome);
            var email = new Email(usuario.Email);
            var newUsuario = new Usuario(
                Guid.NewGuid(),
                nome,
                email,
                usuario.Senha,
                usuario.Username,
                usuario.Ativo,
                usuario.DataCriacao
            );
            await _usuarioRepository.AddAsync(newUsuario);
            var error = new ErroDTO(
                mensagem: usuario == null ? "Usuario not found" : "Success",
                detalhes: usuario == null ? "No user data provided" : "Usuario added successfully",
                codigo: usuario == null ? 404 : 200
            );
            return new UsuarioDTO.ResponseUsuario
            {
                Usuario = newUsuario,
                Erro = error
            };

        }

        public async Task<UsuarioDTO.ResponseUsuario> Update(Guid id, UsuarioDTO.RequestAddUpdateUsuario usuario)
        {
            var existingUsuario = await _usuarioRepository.GetByIdAsync(id);
            existingUsuario.AtualizarUsuario(
                new Nome(usuario.Nome),
                new Email(usuario.Email),
                usuario.Senha,
                usuario.Username,
                usuario.Ativo
            );
            await _usuarioRepository.UpdateAsync(existingUsuario);
            var error = new ErroDTO(
                mensagem: usuario == null ? "Usuario not found" : "Success",
                detalhes: usuario == null ? $"No user found with id {id}" : "Usuario updated successfully",
                codigo: usuario == null ? 404 : 200
            );
            return new UsuarioDTO.ResponseUsuario
            {
                Usuario = existingUsuario,
                Erro = error
            };

        }

        public async Task<UsuarioDTO.ResponseDeleteUsuario> Delete(Guid id)
        {
            await _usuarioRepository.DeleteAsync(id);
            var error = new ErroDTO(
                mensagem: "Usuario deleted successfully",
                detalhes: $"Usuario with id {id} has been deleted",
                codigo: 200
            );
            return new UsuarioDTO.ResponseDeleteUsuario
            {
                Erro = error
            };
        }
    }
}