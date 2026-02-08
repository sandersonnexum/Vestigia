using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Domain.Enums;
using Vestigia.Domain.ValueObjects;

namespace Vestigia.Domain.Entities
{
    public class Transacao
    {
        public Guid Id {get; private set;}
        public Guid IdConta {get; private set;}
        public Guid IdCategoria {get; private set;}
        public Monetario Valor {get; private set;}
        public string Descricao {get; private set;}
        public DateTime Data {get; private set;}
        public TipoTransacao Tipo {get; private set;}
        public List<Guid> IdTags {get; private set;}

        public virtual Conta Conta { get; set; }
        public virtual ICollection<Categoria> Categorias { get; set; }
        public virtual ICollection<Tag> Tags { get; private set; } = new List<Tag>();
        
    }
}