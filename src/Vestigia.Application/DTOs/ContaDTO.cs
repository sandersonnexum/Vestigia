using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Domain.Enums;
using Vestigia.Domain.ValueObjects;

namespace Vestigia.Application.DTOs
{
    public class ContaDTO
    {
        public class RequestAddUpConta
        {
            public string Nomeconta { get; set; }
            public decimal Saldo { get; set; }
            public TipoConta Tipo { get; set; }
            public DateTime DataCriacao { get; set; }
        }
    }
}