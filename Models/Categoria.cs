using System.ComponentModel.DataAnnotations;

namespace AlMocar.Models
{
    public class Categoria
    {
        [Key]
        [Display(Name = "Código")]
        public int CategoriaId {get; set;}
        [Display (Name = "Nome da Categoria")]
        [Required(ErrorMessage = "Informe o nome da Categoria")]
        public string NomeCategoria {get; set;}

        public  List <Item> Items{get; set;}
    }
}