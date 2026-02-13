using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vestigia.Domain.Entities;
using Vestigia.Domain.ValueObjects;

namespace Vestigia.Application.DTOs
{
    public class UsuarioDTO
    {
        public class RequestAddUpdateUsuario
        {
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Senha { get; set; }
            public string Username { get; set; }
            public bool Ativo { get; set; }
            public DateTime DataCriacao { get; set; }
        }

        public class ResponseUsuario
        {
            public Usuario Usuario { get; set; }
            public ErroDTO Erro { get; set; }
        }
    
        public class ResponseGetAllUsuarios
        {
            public List<Usuario> Usuarios { get; set; }
            public ErroDTO Erro { get; set; }
        }

        public class ResponseDeleteUsuario
        {
            public ErroDTO Erro { get; set; }
        }
    }
}