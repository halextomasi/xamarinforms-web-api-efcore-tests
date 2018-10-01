using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controle.API.Models
{
    public class Contribuinte
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required (ErrorMessage ="Favor informar um CPF válido para o contribuinte.")]
        [StringLength(11, MinimumLength = 11)]
        public string CPF { get; set; }
        
        [Required(ErrorMessage = "Favor informar o nome do contribuinte.")]
        [StringLength(100)]
        public string Nome { get; set; }

        [MinLength(1)]
        public int NumeroDependentes { get; set; }
        
        [Required(ErrorMessage = "Favor informar o valor da renda bruta mensal do contribuinte.")]
        [DataType(DataType.Currency)]
        public double RendaBrutaMensal { get; set; }
    }
}