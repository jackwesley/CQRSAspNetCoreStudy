using Eventos.IO.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Eventos.Commands
{
    public abstract class BaseEventoCommand : Command
    {
        public Guid Id { get;  set; }
        public string Nome { get;  set; }
        public string DescricaoCurta { get;  set; }
        public string DescricaoLonga { get;  set; }
        public DateTime DataInicio { get;  set; }
        public DateTime DataFim { get;  set; }
        public bool Gratuito { get;  set; }
        public decimal Valor { get;  set; }
        public bool Online { get;  set; }
        public string NomeEmpresa { get;  set; }
        public Guid OrganizadorId { get; set; }
        public Guid CategoriaId { get;  set; }

    }
}
