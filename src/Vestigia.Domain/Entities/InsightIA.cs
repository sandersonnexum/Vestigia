using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Domain.Enums;

namespace Vestigia.Domain.Entities
{
    public class InsightIA
    {
        private Guid Id {get; set;}
        private Guid IdEntidadeRelacionada {get; set;}
        private Guid IdUsuario {get; set;}
        private TipoInsight Tipo {get; set;}
        private DateTime DataGeracao {get; set;}
        private string ModeloOrigem {get; set;} 
        private string Conteudo {get; set;}
        public virtual Usuario Usuario { get; set; }
    }
}