using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Domain.Enums;
using Vestigia.Domain.ValueObjects;

namespace Vestigia.Domain.Entities
{
    public class Conta
    {
        public Guid Id {get; private set;}
        public Guid IdUsuario {get; private set;}
        public Nome NomeConta {get; private set;}
        public Monetario Saldo {get; private set;}
        public Monetario SaldoInicial {get; private set;}
        public string NumeroConta {get; private set;}
        public TipoConta Tipo {get; private set;}
        public DateTime DataCriacao {get; private set;}

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Transacao> Transacoes { get; set; }
        public virtual ICollection<LogSaldo> LogSaldos { get; set; }
    }
}