using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vestigia.Application.DTOs;
using Vestigia.Application.UseCases;
using Vestigia.Application.UseCases.ContaUC;

namespace Vestigia.API.Controllers
{
    [Route("vestigia/conta")]
    public class ContaController : ControllerBase
    {
        private readonly ContaUC _contaUC;
        private readonly ILogger<ContaController> _logger;
        public ContaController(ContaUC contaUC, ILogger<ContaController> logger)
        {
            _contaUC = contaUC;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContaById(Guid id)
        {
            try
            {
                var conta = await _contaUC.GetContaByIdAsync(id);
                if (conta == null)
                {
                    return NotFound();
                }
                return Ok(conta);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving conta with ID {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContas()
        {
            try
            {
                var contas = await _contaUC.GetAllContasAsync();
                return Ok(contas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all contas");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("{idUsuario}")]
        public async Task<IActionResult> AddConta(Guid idUsuario, [FromBody] ContaDTO.RequestAddUpConta conta)
        {
            try
            {
    
                await _contaUC.AddContaAsync(idUsuario, conta);
                return Ok("Conta adicionada com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding new conta");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}/{idUsuario}")]
        public async Task<IActionResult> UpdateConta(Guid id, Guid idUsuario, [FromBody] ContaDTO.RequestAddUpConta conta)
        {
         
            try
            {
                /*if (id != conta.Id)
                {
                    return BadRequest("ID mismatch");
                }*/
                await _contaUC.UpdateContaAsync(idUsuario, id, conta);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating conta with ID {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConta(Guid id)
        {
            try
            {
                await _contaUC.DeleteContaAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting conta with ID {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}