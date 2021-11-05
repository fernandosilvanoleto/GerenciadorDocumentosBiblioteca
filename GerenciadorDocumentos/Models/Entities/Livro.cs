using GerenciadorDocumentos.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDocumentos.Models.Entities
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Editora { get; set; }
        public string Genero { get; set; }
        public ELivro Status { get; set; }
        public string ISBN { get; set; }
        public decimal Preco { get; set; }
        public ICollection<LivroAutor> LivrosAutores { get; set; }
    }
}
