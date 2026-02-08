using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Domain.ValueObjects;

namespace Vestigia.Domain.Entities
{
    public class LogSaldo
    {
        public Guid Id { get; private set; }
        public Guid IdConta { get; private set; }
        public Guid IdUsuario { get; private set; }
        public DateOnly MesReferencia { get; private set; }
        public Monetario SaldoFechamento { get; private set; }
        public virtual Conta Conta { get; set; }
    }
}