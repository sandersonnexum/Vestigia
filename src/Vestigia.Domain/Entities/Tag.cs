using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vestigia.Domain.Entities
{
    public class Tag : Classificador
    {
        private string CorHex {get; set;}
        public virtual Transacao Transacao { get; set; }
    }
}