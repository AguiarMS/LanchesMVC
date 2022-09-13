using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LanchesMVC.Models
{

    //Mapeamento para tabela Categoria
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        //Propriedades da classe CategoriaNome
        [StringLength(100, ErrorMessage = "O tamanho max é 100 caracteres")]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        [Display(Name = "Nome")]
        public string CategoriaNome { get; set; }

        //Propriedades da classe Descrição
        [StringLength(100, ErrorMessage = "O tamanho max é 100 caracteres")]
        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }


        //Relacionamento de 1:N
        public List<Lanche> Lanches { get; set; }
    }
}