using System;

namespace GerenciadorDocumentos.Models.ViewModels
{
    public class LivrosCheckBoxViewModel
    {
        // INFORMAÇÕES SOBRE OS LIVROS
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }

        // ESSA VARIÁVEL CHECKED É PARA MARCAR LÁ NO FRONT HEIN PORRA
        public bool Checked { get; set; }
    }
}
