using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDocumentos.Models.ViewModels
{
    public class CheckBoxAutorsViewModel
    {
        // INFORMAÇÕES DOS AUTORES
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public char SiglaNome { get; set; }
        public bool Brasileiro { get; set; }
    }
}
