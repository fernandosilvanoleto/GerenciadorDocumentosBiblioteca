using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDocumentos.Models.Entities
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public char SiglaNome { get; set; }
        public int CNPJ { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Brasileiro { get; set; }
        public ICollection<LivroAutor> LivrosAutores {get; set;}
    }
}
