using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDocumentos.Models.ViewModels
{
    public class LivrosViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public List<CheckBoxAutorsViewModel> Autores { get; set; }
    }
}
