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
        private Guid IdLembrete {get; set;}
        private decimal Valor {get; set;}
        private string Descricao {get; set;}
        private DateTime Data {get; set;}
        private StatusTransacao Status {get; set;}
    }
}