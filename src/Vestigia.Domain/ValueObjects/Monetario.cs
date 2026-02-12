using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vestigia.Domain.ValueObjects
{
    public record Monetario
    {
        public decimal Valor { get;}

        public Monetario(decimal valor)
        {
            Valor = valor;
        }
        public static Monetario Create(decimal valor)
        {
            if (valor < 0)
                throw new ArgumentException("O valor monetário não pode ser negativo.");

            return new Monetario(valor);
        }
    }
}