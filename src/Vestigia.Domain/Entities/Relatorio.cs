using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Domain.Enums;

namespace Vestigia.Domain.Entities
{
    public class Relatorio
    {
        private Guid Id {get; set;}
        private Guid IdUsuario {get; set;}
        private DateTime PeriodoInicio {get; set;}
        private DateTime PeriodoFim{get; set;}
        private decimal TotalEntradas {get; set;}
        private decimal TotalSaida {get; set;}
        private decimal SaldoFinal {get; set;}
        private DateTime DataGeracao {get; set;}
        private TipoRelatorio Tipo {get; set;}
        private string Resumo {get; set;}
    }
}