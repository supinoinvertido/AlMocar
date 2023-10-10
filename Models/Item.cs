using System.ComponentModel.DataAnnotations;

namespace AlMocar.Models
{
    public class Item
    {
         [Display(Name ="Informe o itemid")]
        [Required(ErrorMessage ="Informe o itemid")]
        [MinLength(3, ErrorMessage ="itemid deve ter no minimo {1} caracteries")]
        [MaxLength(25, ErrorMessage ="itemid deve ter no minimo {1} caracteries")]
        public int itemid{get; set;}
        
        
        [Display(Name ="Informe o Nome do produto")]
        [Required(ErrorMessage ="Informe o Nome do produto")]
        [MinLength(5, ErrorMessage ="Nome do produto deve ter no minimo {1} caracteries")]
        [MaxLength(10, ErrorMessage ="Nome do produto deve ter no minimo {1} caracteries")]
        public string Nome{get;set;}



        [Display(Name ="Descrição Curta do produto")]
        [Required(ErrorMessage ="Descrição Curta  do produto")]
        [MinLength(5, ErrorMessage ="Descrição Curta  deve ter no minimo {1} caracteries")]
        [MaxLength(50, ErrorMessage ="Descrição Curta  deve ter no minimo {1} caracteries")]
        public int DescricaoCurta{get;set;}

        [Display(Name ="Descrição Curta do produto")]
        [Required(ErrorMessage ="Descrição Curta  do produto")]
        [MinLength(25, ErrorMessage ="Descrição Curta  deve ter no minimo {1} caracteries")]
        [MaxLength(150, ErrorMessage ="Descrição Curta  deve ter no minimo {1} caracteries")]
        public int DescricaoDetalhada{get;set;}


        [Display(Name ="Informe o caminho da Imagem")]
        public string ImagemUrl{get; set;}
        
        [Display(Name ="Informe o caminho da Imagem Pequena")]
        public string ImagemPequenaUrl{get; set;}


        [Display(Name ="Informe o valor do Item")]
        [Required(ErrorMessage ="O valor do Item deve ser informado")]
        [Range(1,100, ErrorMessage ="O valor deve estar entre {1} e {2}")]
        public double Valor{get; set;}

        [Display(Name = "Item esta sendo feito")]
        public bool Ativo{get; set;}

        public bool Destaque{get; set;}

        [Display(Name ="CategoriaId do item")]
        [Required(ErrorMessage ="Informe a CategoriaId do item")]
        public int CategoriaId{get; set;}

        [Display(Name ="Categoria do item")]
        [Required(ErrorMessage ="Informe a Categoria do item")]
        public virtual Categoria Categoria{get; set;}

    }
}