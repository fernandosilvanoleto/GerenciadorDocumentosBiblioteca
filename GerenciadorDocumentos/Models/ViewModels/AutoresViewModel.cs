using System.Collections.Generic;

namespace GerenciadorDocumentos.Models.ViewModels
{
    public class AutoresViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public char SiglaNome { get; set; }
        public bool Brasileiro { get; set; }
        public List<LivrosCheckBoxViewModel> Livros { get; set; }
    }
}
