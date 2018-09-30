using System;
using System.Net.Http;
using System.Text;
using Controle.API.Models;

namespace Controle.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            AdicionarContribuinteAPI();
        }

        static void CarregarContribuintesAPI()
        {
            try
            {
                var uri = new Uri("http://localhost:5001/api/contribuinte/obtercontribuintes");

                var client = new HttpClient();
                var resposta = client.GetAsync(uri).Result;

                if (resposta.IsSuccessStatusCode)
                {
                    var resultado = resposta.Content.ReadAsStringAsync().Result;
                    // var contribuintes = JsonConvert.DeserializeObject<IList<Contribuinte>>(resultado);
                }
                else
                {
                    throw new Exception("Perfis não encontrados!");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;

            }
        }

        static void AdicionarContribuinteAPI()
        {
            try
            {
                Contribuinte contribuinte = new Contribuinte()
                {
                    Id = 0,
                    Nome = "Matheus",
                    CPF = "01029320239",
                    RendaBrutaMensal = 1000
                };

                var uri = new Uri("http://localhost:5001/api/contribuinte/criarcontribuinte");

                var conteudoJson = Newtonsoft.Json.JsonConvert.SerializeObject(contribuinte);
                var conteudoJsonString = new StringContent(conteudoJson, Encoding.UTF8, "application/json");

                var client = new HttpClient();
                var resposta = client.PutAsync(uri, conteudoJsonString).Result;

                if (!resposta.IsSuccessStatusCode)
                {
                    throw new Exception("Dados do investidor não encontrado!");
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}