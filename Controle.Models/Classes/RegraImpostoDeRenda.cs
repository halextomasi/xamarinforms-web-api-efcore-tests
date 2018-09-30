using Realms;

namespace Controle.Models.Classes
{
    public class RegraImpostoDeRenda
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int QtdSalarioMinimoDe { get; set; }
        public int QtdSalarioMinimoPara { get; set; }
        public double Aliquota { get; set; }
    }
}