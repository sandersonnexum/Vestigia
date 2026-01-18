using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vestigia.Domain.Entities
{
    public class Lembrete
    {
        private Guid Id {get; set;}
        private Guid IdTransacao {get; set;}
        private string Titulo {get; set;}
        private string Descricao {get; set;}
        private decimal Valor {get; set;}
        private DateTime DataVencimento {get; set;}
        private bool Pago {get; set;}
        public virtual Transacao Transacao { get; set; }

    }
}