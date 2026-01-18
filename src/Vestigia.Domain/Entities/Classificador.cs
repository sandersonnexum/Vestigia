using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vestigia.Domain.Entities
{
    public class Classificador
    {
        protected Guid Id {get; set;}
        protected Guid IdTransacao {get; set;}
        protected string Nome {get; set;}
    }
}