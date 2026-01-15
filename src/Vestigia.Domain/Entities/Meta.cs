using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Domain.Enums;

namespace Vestigia.Domain.Entities
{
    public class Meta
    {
        private Guid Id {get; set;}
        private Guid IdCategoria {get; set;}
        private Guid IdConta {get; set;}
        private string Descricao {get; set;}
        private decimal ValorAlvo {get; set;}
        private decimal ValorAtual {get; set;}
        private DateTime DataInicio {get; set;}
        private DateTime DataFim {get; set;}
        private StatusMeta Status {get; set;}
    }
}