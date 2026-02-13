using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vestigia.Application.DTOs
{
    public class ErroDTO
    {
        public string Mensagem { get; set; }
        public string Detalhes { get; set; }
        public int Codigo { get; set; }

        public ErroDTO(string mensagem, string detalhes, int codigo)
        {
            Mensagem = mensagem;
            Detalhes = detalhes;
            Codigo = codigo;
        }

    }
}