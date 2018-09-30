using Realms;

namespace Controle.Models.Classes
{
    public class Contribuinte : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string CPF { get; set; }

        public string Nome { get; set; }

        public double RendaBrutaMensal { get; set; }
    }
}
