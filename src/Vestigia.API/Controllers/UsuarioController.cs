using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vestigia.Application.DTOs;
using Vestigia.Application.UseCases.UsuarioUC;
using Vestigia.Domain.Entities;


namespace Vestigia.API.Controllers
{
    [Route("vestigia/usuario")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioUC _usuarioUC;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(UsuarioUC usuarioUC, ILogger<UsuarioController> logger)
        {
            _usuarioUC = usuarioUC;
            _logger = logger;
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetUsuarioById(Guid id)
        {
            try
            {
                var usuario = await _usuarioUC.GetById(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting usuario with id {id}");
                return BadRequest($"Error getting usuario with id {id}");
            }
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUsuarioByEmail(string email)
        {
            try
            {
                var usuario = await _usuarioUC.GetByEmail(email);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting usuario with email {email}");
                return BadRequest($"Error getting usuario with email {email}");
            }
        }

        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetUsuarioByUsername(string username)
        {
            try
            {
                var usuario = await _usuarioUC.GetByUsername(username);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting usuario with username {username}");
                return BadRequest($"Error getting usuario with username {username}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            try
            {
                var usuarios = await _usuarioUC.GetAll();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all usuarios");
                return BadRequest("Error getting all usuarios");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUsuario([FromBody] UsuarioDTO.RequestAddUpdateUsuario usuario)
        {
            try
            {
                await _usuarioUC.Add(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding usuario");
                return BadRequest("Error adding usuario");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(Guid id, [FromBody] UsuarioDTO.RequestAddUpdateUsuario usuario)
        {
            try
            {
                await _usuarioUC.Update(id, usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating usuario with id {id}");
                return BadRequest($"Error updating usuario with id {id}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(Guid id)
        {
            try
            {
                _usuarioUC.Delete(id);
                return Ok($"Delete usuario with id {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting usuario with id {id}");
                return BadRequest($"Error deleting usuario with id {id}");
            }
        }

    }
}