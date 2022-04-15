using System;

namespace LojaQuadrinhos.Services.DTO
{
    public class ComicBookDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public string DataPublicacao { get; set; }

        public string Autor { get; set; }

        public int Estoque { get; set; }

        public ComicBookDTO()
        {

        }

        public ComicBookDTO(string titulo, string descricao, decimal preco,
                         string datapublicacao, string autor, int estoque)
        {
            Titulo = titulo;
            Descricao = descricao;
            Preco = preco;
            DataPublicacao = datapublicacao;
            Autor = autor;
            Estoque = estoque;
        }
    }
}
