using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Domain.Enums;

namespace Vestigia.Domain.Entities
{
    public class Transacao
    {
        private Guid Id {get; set;}
        private Guid IdConta {get; set;}
        private Guid IdUsuario {get; set;}
        private decimal Valor {get; set;}
        private string Descricao {get; set;}
        private DateTime Data {get; set;}
        private StatusTransacao Status {get; set;}
        public virtual Conta Conta { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Categoria> Categorias { get; set; }
        public virtual ICollection<Lembrete> Lembretes { get; set; }
    }
}