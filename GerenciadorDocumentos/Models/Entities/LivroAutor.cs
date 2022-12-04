using System.ComponentModel.DataAnnotations;

namespace GerenciadorDocumentos.Models.Entities
{
    public class LivroAutor
    {
        [Key]
        public int IdLivroAutor { get; set; }
        public int LivroId { get; set; }
        public int AutorId { get; set; }

        public Livro Livro { get; set; }
        public Autor Autor { get; set; }
    }
}
