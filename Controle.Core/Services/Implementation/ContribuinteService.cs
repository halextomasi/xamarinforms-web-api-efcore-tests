using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Controle.Models.Classes;
using Newtonsoft.Json;

namespace Controle.Core.Services.Implementation
{
    public class ContribuinteService : IContribuinteService
    {
        public async Task<IList<Contribuinte>> ObterTodos()
        {
            IList<Contribuinte> retorno = new List<Contribuinte>();
            
            try
            {
                var uri = new Uri("http://localhost:5001/api/contribuinte/obtercontribuintes");

                var client = new HttpClient();
                var resposta = client.GetAsync(uri).Result;

                if (resposta.IsSuccessStatusCode)
                {
                    var resultado = resposta.Content.ReadAsStringAsync().Result;
                    retorno = JsonConvert.DeserializeObject<IList<Contribuinte>>(resultado);
                }
            }
            catch (Exception exception)
            {
                //MENSAGEM DE ERRO COM A CONEXÃO.
                //MANTERA O QUE TEM NO REALM
            }

            return retorno;
        }

        public bool AdicionarContribuinte(Contribuinte contribuinte)
        {
            /*var contribuinte = new Contribuinte()
            {
                Id = 0,
                Nome = "Matheus",
                CPF = "01029320239",
                RendaBrutaMensal = 1000
            };*/

            var uri = new Uri("http://localhost:5001/api/contribuinte/criarcontribuinte");

            var conteudoJson = Newtonsoft.Json.JsonConvert.SerializeObject(contribuinte);
            var conteudoJsonString = new StringContent(conteudoJson, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var resposta = client.PutAsync(uri, conteudoJsonString).Result;

            if (!resposta.IsSuccessStatusCode)
            {
                //MENSAGEM DE ERRO COM A CONEXÃO.
                //MANTERA O QUE TEM NO REALM
            }
            else
            {
                return Convert.ToBoolean(resposta.Content.ReadAsStringAsync().Result);
            }

            return false;
        }
    }
}
