using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Domain.Enums;

namespace Vestigia.Domain.Entities
{
    public class Alerta
    {
        private Guid Id {get; set;}
        private string Mensagem {get; set;}
        private TipoAlerta Tipo {get; set;}
        private NivelPrioridade Nivel {get; set;}
        private DateTime DataCriacao {get; set;}
        private bool Lido {get; set;}
    }
}