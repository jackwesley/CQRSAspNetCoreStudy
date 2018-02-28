using Eventos.IO.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Eventos
{
    public class Categoria : Entity<Categoria>
    {
        public Categoria(Guid id)
        {
            Id = id;

        }

        //EF propriedade de Navegação
        public virtual ICollection<Evento> Eventos { get; private set; }


        public string Nome { get; private set; }
        
        //construtor para EF
        public Categoria() { }

        public override bool EhValido()
        {
            return true;
        }
    }
}