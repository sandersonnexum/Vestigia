using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks;
using Vestigia.Domain.Enums;

namespace Vestigia.Domain.Entities
{
    public class Categoria : Classificador
    {
        private TipoTransacao Tipo {get; set;}
        public virtual Transacao Transacao { get; set; } 
        public virtual ICollection<Meta> Metas { get; set; }
    }
}