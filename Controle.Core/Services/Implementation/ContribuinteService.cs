using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Controle.Core.Models;
using Newtonsoft.Json;

namespace Controle.Core.Services.Implementation
{
    public class ContribuinteService : IContribuinteService
    {
        private readonly IDialogService _dialogService;
        
        public ContribuinteService(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
        
        public IEnumerable<Contribuinte> ObterTodos()
        {
            var uri = new Uri("http://localhost:5001/api/contribuinte/obtercontribuintes");

            var client = new HttpClient();
            var resposta = client.GetAsync(uri).Result;

            if (resposta.IsSuccessStatusCode)
            {
                var resultado = resposta.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<IEnumerable<Contribuinte>>(resultado);
            }

            return new List<Contribuinte>();;
        }

        public bool AdicionarContribuinte(Contribuinte contribuinte)
        {
            var uri = new Uri("http://localhost:5001/api/contribuinte/criarcontribuinte");

            var conteudoJson = Newtonsoft.Json.JsonConvert.SerializeObject(contribuinte);
            var conteudoJsonString = new StringContent(conteudoJson, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var resposta = client.PutAsync(uri, conteudoJsonString).Result;

            return resposta.IsSuccessStatusCode;
        }
    }
}
