using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciarDocumentos.Models.Entities
{
    public class Documento
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Item obrigatório")]
        public string Codigo { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "Item obrigatório")]
        public string Titulo { get; set; }

        [Display(Name = "Revisão")]
        [Required(ErrorMessage = "Item obrigatório")]
        public char Revisao { get; set; }

        [Display(Name = "Data Planejada")]
        [Required(ErrorMessage = "Item obrigatório")]
        [DataType(DataType.Date)]
        public DateTime? DataPlanejada { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto", AllowEmptyStrings = false)]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal Valor { get; set; }
    }
}