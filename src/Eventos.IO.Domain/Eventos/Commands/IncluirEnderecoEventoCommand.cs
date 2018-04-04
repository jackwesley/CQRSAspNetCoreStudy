using Eventos.IO.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Eventos.Commands
{
    public class IncluirEnderecoEventoCommand : Command
    {

        public IncluirEnderecoEventoCommand(Guid id,
            string logradouro,
            string numero,
            string complemento,
            string bairro,
            string cep,
            string cidade,
            string estado,
            Guid? eventoId
            )
        {
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cep;
            Cidade = cidade;
            Estado = estado;
            EventoId = eventoId;
        }

        public Guid Id { get; set; }
        public string Logradouro { get;  set; }
        public string Numero { get;  set; }
        public string Complemento { get;  set; }
        public string Bairro { get;  set; }
        public string CEP { get;  set; }
        public string Cidade { get;  set; }
        public string Estado { get;  set; }
        public Guid? EventoId { get; set; }


    }
}
