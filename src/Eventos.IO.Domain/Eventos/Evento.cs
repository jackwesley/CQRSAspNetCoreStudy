﻿using Eventos.IO.Domain.Core.Models;
using Eventos.IO.Domain.Organizadores;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Eventos
{

    public class Evento : Entity<Evento>
    {
        public Evento(string nome, DateTime dataInicio, DateTime dataFim, bool gratuito,
                      decimal valor, bool online, string nomeEmpresa)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeEmpresa = nomeEmpresa;

        }

        private Evento() { }

        public string Nome { get; private set; }
        public string DescricaoCurta { get; private set; }
        public string DescricaoLonga { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public bool Gratuito { get; private set; }
        public decimal Valor { get; private set; }
        public bool Online { get; private set; }
        public string NomeEmpresa { get; private set; }
        public bool Excluido { get; private set; }        
        public ICollection<Tags> Tags { get; private set; }
        public Guid? CategoriaId { get; private set; }
        public Guid? EnderecoId { get; private set; }
        public Guid OrganizadorId { get; private set; }

        //EF propriedades de navegação
        public virtual Categoria Categoria { get; private set; }
        public virtual Endereco Endereco { get; private set; }
        public virtual Organizador Organizador { get; private set; }

        public void AtribuirEndereco(Endereco endereco)
        {
            if (!endereco.EhValido()) return;
            Endereco = endereco;
        }

        public void AtribuirCategoria(Categoria categoria)
        {
            if (!categoria.EhValido()) return;
            Categoria = Categoria;
        }

        public void ExcluirEvento()
        {
            //TODO: Deve validar regra?
            Excluido = true;
        }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarNome();
            ValidaValor();
            ValidarData();
            ValidarLocal();
            ValidarNomeEmpresa();
            ValidationResult = Validate(this);

            //Validações adicionais
            ValidarEndereco();
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome do evento precisa ser fornecido")
                .Length(2, 150).WithMessage("Tamanho deve estar entre 2 e 150 caracteres");
        }

        private void ValidaValor()
        {
            if (!Gratuito)
                RuleFor(c => c.Valor)
                    .ExclusiveBetween(1, 50000).WithMessage("Valor deve estar entre 1 e 50000");

            if (Gratuito)
                RuleFor(c => c.Valor)
                    .Equal(0).When(e => Gratuito)
                    .WithMessage("Valor nao deve ser diferente de 0 para evento gratuito");
        }

        private void ValidarData()
        {

            RuleFor(c => c.DataInicio)
                .LessThan(c => DataFim)
                .WithMessage("Data inicio deve ser maior que a data final");

            RuleFor(c => c.DataInicio)
                .GreaterThan(DateTime.Now)
                .WithMessage("Data inicio deve ser maior que a data Atual");
        }

        private void ValidarLocal()
        {
            if (Online)
                RuleFor(c => c.Endereco)
                        .Null().When(c => c.Online)
                        .WithMessage("Evento online nao necessita de endereço");

            if (!Online)
                RuleFor(c => c.Endereco)
                    .NotNull().When(c => c.Online == false)
                    .WithMessage("Evento presencial precisa de endereço");
        }

        private void ValidarNomeEmpresa()
        {
            RuleFor(c => c.NomeEmpresa)
                .NotEmpty().WithMessage("O Nome da empresa precisa ser fornecido")
                .Length(2, 150).WithMessage("O nome do organizador precisa ter entre 2 e 150 caracteres");
        }

        private void ValidarEndereco()
        {
            if (Online) return;
            if (Endereco.EhValido()) return;

            foreach(var error in Endereco.ValidationResult.Errors)
            {
                ValidationResult.Errors.Add(error);
            }
        }
        #endregion

        public static class EventoFactory
        {
            public static Evento NovoEventoCompleto(Guid id, string nome, string descCurta, string descLonga, DateTime dataInicio,
                            DateTime dataFim, bool gratuito, decimal valor, bool online, string nomeEmpresa, Guid? organizadorId, Endereco endereco, Guid categoriaId)
            {
                var evento = new Evento()
                {
                    Id = id,
                    Nome = nome,
                    DescricaoCurta  = descCurta,
                    DescricaoLonga = descLonga,
                    DataInicio = dataInicio,
                    DataFim = dataFim,
                    Gratuito = gratuito,
                    Valor = valor,
                    Online = online,
                    NomeEmpresa = nomeEmpresa,
                    Endereco = endereco,
                    CategoriaId = categoriaId
                };
                if (organizadorId.HasValue)
                    evento.OrganizadorId = organizadorId.Value;

                if (online)
                    evento.Endereco = null;
                return evento;
            }
        }
    }


}
