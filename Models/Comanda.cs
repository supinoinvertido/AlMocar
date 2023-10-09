using System.ComponentModel.DataAnnotations;

namespace AlMocar.Models
{
    public class Comanda
    {
         [Display(Name ="Informe o nome do lanche")]
        [Required(ErrorMessage ="Informe o nome do lanche")]
        [MinLength(3, ErrorMessage ="Nome do lanche deve ter no minimo {1} caracteries")]
        [MaxLength(125, ErrorMessage ="Nome do lanche deve ter no minimo {1} caracteries")]
        public int Lanche{get; set;}
    }
}