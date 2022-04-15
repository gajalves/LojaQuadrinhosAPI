using LojaQuadrinhos.Core.Exceptions;
using LojaQuadrinhos.Domain.Entities;
using LojaQuadrinhos.Domain.Validators;
using System;
using System.Collections.Generic;

namespace LojaQuadrinhos.Domain.Entities
{
    public class ComicBook : Base
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }
        
        public string DataPublicacao { get; set; }
        
        public string Autor { get; set; }

        public int Estoque { get; set; }

        protected ComicBook() { }

        public ComicBook(string titulo, string descricao, decimal preco, 
                         string datapublicacao, string autor, int estoque)
        {
            Titulo = titulo;
            Descricao = descricao;
            Preco = preco;
            DataPublicacao = datapublicacao;
            Autor = autor;
            Estoque = estoque;
            _erros = new List<string>();

            Validate();
        }

        public void SetTitulo(string titulo)
        {
            Titulo = titulo;
            Validate();
        }

        public void SetDescricao(string descricao)
        {
            Descricao = descricao;
            Validate();
        }

        public void SetPreco(decimal preco)
        {
            Preco = preco;
            Validate();
        }

        public void SetDataPublicacao(string datapublicacao)
        {
            DataPublicacao = datapublicacao;
            Validate();
        }

        public void SetAutor(string autor)
        {
            Autor = autor;
            Validate();
        }

        public void SetEstoque(int estoque)
        {
            Estoque = estoque;
            Validate();
        }

        public override bool Validate()
        {
            ComicBookValidator validator = new ComicBookValidator();
            var validacao = validator.Validate(this);

            if (!validacao.IsValid)
            {
                foreach (var error in validacao.Errors)
                {
                    _erros.Add(error.ErrorMessage);
                }

                throw new DomainException("Alguns campos estão inválidos, por favor corrigir! " + _erros);
            }

            return true;
        }
    }
}
