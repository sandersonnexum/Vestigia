using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Domain.Enums;

namespace Vestigia.Domain.Entities
{
    public class RelatorioIA
    {
        public Guid Id {get; private set;}
        public Guid IdEntidadeRelacionada {get; set;}
        public Guid IdUsuario {get; set;}
        public DateTime Data {get; set;}
        public TipoRelatorio Tipo {get; set;}
        public string Conteudo {get; set;}        
        public EntidadeRelacionada EntidadeRelacionada {get; set;}
        public virtual Usuario Usuario { get; set; }
    }
}