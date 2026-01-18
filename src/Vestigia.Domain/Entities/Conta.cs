using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Domain.Enums;

namespace Vestigia.Domain.Entities
{
    public class Conta
    {
        private Guid Id {get; set;}
        private Guid IdUsuario {get; set;}
        private string NomeConta {get; set;}
        private decimal Saldo {get; set;}
        private decimal SaldoInicial {get; set;}
        private TipoConta Tipo {get; set;}
        private bool Ativo {get; set;}
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Transacao> Transacoes { get; set; }
        public virtual ICollection<Meta> Metas { get; set; }
    }
}