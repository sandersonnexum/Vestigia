using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks;
using Vestigia.Domain.Enums;
using Vestigia.Domain.ValueObjects;

namespace Vestigia.Domain.Entities
{
    public class Categoria
    {
        public Guid Id {get; private set;}
        public Guid IdUsuario {get; private set;}
        public Nome Nome {get; private set;}
        public string Descricao {get; private set;}

        public virtual ICollection<Transacao> Transacoes { get; set; } 
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Meta> Metas { get; set; }
    }
}