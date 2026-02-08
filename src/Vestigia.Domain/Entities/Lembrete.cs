using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Domain.Enums;
using Vestigia.Domain.ValueObjects;

namespace Vestigia.Domain.Entities
{
    public class Lembrete
    {
        public Guid Id {get; private set;}
        public Guid IdUsuario {get; private set;}
        public Nome Nome {get; private set;}
        public string Descricao {get; private set;}
        public Monetario Valor {get; private set;}
        public DateTime DataVencimento {get; private set;}
        public StatusLembrete Status {get; private set;}
        public virtual Usuario Usuario { get; set; }

    }
}