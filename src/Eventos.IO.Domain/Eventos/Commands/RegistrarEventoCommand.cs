﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Eventos.Commands
{
    public class RegistrarEventoCommand : BaseEventoCommand
    {

        public IncluirEnderecoEventoCommand Endereco { get; protected set; }

        public RegistrarEventoCommand(
            string nome,
            string descricaoCurta,
            string descricaoLonga,
            DateTime dataInicio,
            DateTime dataFim,
            bool gratuito,
            decimal valor,
            bool online,
            string nomeEmpresa,
            Guid orgaginzadorId,
            Guid categoriaId,
            IncluirEnderecoEventoCommand endereco
           )
        {

            Nome = nome;
            DescricaoCurta = descricaoCurta;
            DescricaoLonga = descricaoLonga;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeEmpresa = nomeEmpresa;
            OrganizadorId = orgaginzadorId;
            CategoriaId = categoriaId;
            Endereco = endereco;
        }


    }
}
