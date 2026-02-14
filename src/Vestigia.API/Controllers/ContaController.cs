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

        [HttpGet("{idConta}")]
        public async Task<IActionResult> GetContaById(Guid idConta)
        {
            try
            {
                var response = await _contaUC.GetContaByIdAsync(idConta);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving conta with ID {Id}", idConta);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{numeroConta}/numero")]
        public async Task<IActionResult> GetContaByNumero(string numeroConta)
        {
            try
            {
                var response = await _contaUC.GetContaByNumeroAsync(numeroConta);

                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving conta with numero {NumeroConta}", numeroConta);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{idUsuario}/todos")]
        public async Task<IActionResult> GetAllContas(Guid idUsuario)
        {
            try
            {
                var formatId = new Guid(idUsuario.ToString());
                var contas = await _contaUC.GetAllContasAsync(formatId);
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
                var formatId = new Guid(idUsuario.ToString());
                await _contaUC.AddContaAsync(formatId, conta);
                return Ok("Conta adicionada com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding new conta");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConta(Guid id, [FromBody] ContaDTO.RequestAddUpConta conta)
        {
         
            try
            {
                await _contaUC.UpdateContaAsync(id, conta);
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