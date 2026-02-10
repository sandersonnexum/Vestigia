using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Domain.ValueObjects;

namespace Vestigia.Application.DTOs
{
    public class UsuarioDTO
    {
        public class RequestAddUpdate
        {
            public Nome Nome { get; set; }
            public Email Email { get; set; }
            public string Senha { get; set; }
            public string Username { get; set; }
            public bool Ativo { get; set; }
            public DateTime DataCriacao { get; set; }
        }
    }
}