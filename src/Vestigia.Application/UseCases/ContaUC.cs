using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Application.DTOs;
using Vestigia.Application.Services.NumeroConta;
using Vestigia.Domain.Entities;
using Vestigia.Domain.Interfaces;
using Vestigia.Domain.ValueObjects;

namespace Vestigia.Application.UseCases.ContaUC
{
    public class ContaUC
    {
        private readonly IContaRepository _contaRepository;
        public ContaUC(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task<Conta> GetContaByIdAsync(Guid id)
        {
            return await _contaRepository.GetByIdAsync(id);
        }

        public async Task<List<Conta>> GetAllContasAsync()
        {
            return await _contaRepository.GetAllAsync();
        }

        public async Task AddContaAsync(Guid idUsuario, ContaDTO.RequestAddUpConta conta)
        {
            var numero = NumeroConta.GerarString(10);
            var novaConta = new Conta
            (
                idUsuario,
                Nome.Create(conta.Nomeconta),
                Monetario.Create(conta.Saldo),
                Monetario.Create(conta.Saldo),
                numero,
                conta.Tipo
            );
            await _contaRepository.AddAsync(novaConta);
        }

        public async Task UpdateContaAsync(Guid idUsuario, Guid id, ContaDTO.RequestAddUpConta conta)
        {
            var contaExistente = await _contaRepository.GetByIdAsync(id);
            if (contaExistente == null)
            {
                throw new ArgumentException("Conta não encontrada");
            }
            var contaAtualizada = new Conta(
                contaExistente.Id,
                Nome.Create(conta.Nomeconta),
                Monetario.Create(conta.Saldo),
                Monetario.Create(conta.Saldo),
                contaExistente.NumeroConta,
                conta.Tipo
            );
            await _contaRepository.UpdateAsync(contaAtualizada);
        }

        public async Task DeleteContaAsync(Guid id)
        {
            await _contaRepository.DeleteAsync(id);
        }
    }
}