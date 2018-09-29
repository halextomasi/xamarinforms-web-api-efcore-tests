using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controle.API.Models
{
    public class RegraImpostoDeRenda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int QtdSalarioMinimoDe { get; set; }
        public int QtdSalarioMinimoPara { get; set; }
        public double Aliquota { get; set; }
    }
}