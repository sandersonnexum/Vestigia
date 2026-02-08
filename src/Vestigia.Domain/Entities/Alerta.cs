using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Domain.Enums;

namespace Vestigia.Domain.Entities
{
    public class Alerta
    {
        public Guid Id {get; private set;}
        public Guid IdUsuario {get; private set;}
        public string Mensagem {get; private set;}
        public TipoAlerta Tipo {get; private set;}
        public NivelPrioridade Nivel {get; private set;}
        public DateTime DataCriacao {get; private set;}
        private bool Lido {get; set;}
        public virtual Usuario Usuario { get; set; }
    }
}