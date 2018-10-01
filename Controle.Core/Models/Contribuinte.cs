using System;
using Newtonsoft.Json;

namespace Controle.Core.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Contribuinte
    {
        [JsonProperty]
        public int Id { get; set; }
        
        [JsonProperty]
        public string CPF { get; set; }

        [JsonProperty]
        public string Nome { get; set; }
        
        [JsonProperty]
        public int NumeroDependentes { get; set; }

        [JsonProperty]
        public double RendaBrutaMensal { get; set; }
        
        public string ImpostoDeRenda { get; set; }

        public Contribuinte()
        {
            CPF = String.Empty;
            Nome = String.Empty;
            NumeroDependentes = 0;
            RendaBrutaMensal = 0;
            ImpostoDeRenda = "";
        }
    }
}
