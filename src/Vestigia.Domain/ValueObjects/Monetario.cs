using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vestigia.Domain.ValueObjects
{
    public record Monetario
    {
        public decimal Valor { get; init; }
        public Monetario(decimal valor)
        {
            if (valor < 0)
                throw new ArgumentException("O valor monetário não pode ser negativo.");

            Valor = valor;
        }
    }
}