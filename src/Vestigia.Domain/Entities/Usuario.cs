using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vestigia.Domain.Entities
{
    public class Usuario
    {
        private Guid Id {get; set;}
        private string Nome {get; set;}
        private string Email {get; set;}
        private string SenhaHash {get; set;}
        private bool Ativo {get; set;}
        private DateTime DataCriacao {get;set;}

        public Usuario(string nomeConta, string email, string senha, DateTime data)
        {
            Id = Guid.NewGuid();
            Nome = nomeConta;
            Email = email;
            SenhaHash = senha;
            Ativo = true;
            DataCriacao = data;
        }

        private Usuario() {}
    }
}