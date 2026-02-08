using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Domain.Enums;
using Vestigia.Domain.ValueObjects;

namespace Vestigia.Domain.Entities
{
    public class Meta
    {
        public Guid Id {get; private set;}
        public Guid IdUsuario {get; private set;}
        public Guid IdCategoria {get; private set;}
        public Nome Nome {get; private set;}
        public string Descricao {get; private set;}
        public Monetario ValorAlvo {get; private set;}
        public Monetario ValorAlcancado {get;private set;}
        public DateTime DataCriacao {get; private set;}
        public DateTime Prazo {get; private set;}
        public StatusMeta Status {get; private set;}
        public virtual Categoria Categoria { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}