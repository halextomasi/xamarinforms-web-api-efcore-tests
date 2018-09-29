using Controle.API.Repositories;
using Controle.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Controle.API.Repositories.Interfaces;

namespace Controle.API.Controllers
{
    [Route("api/[controller]")]
    public class ContribuinteController : Controller
    {
        private readonly IContribuinteRepository _contribuinteRepository;

        public ContribuinteController(IContribuinteRepository contribuinteRepository)
        {
            _contribuinteRepository = contribuinteRepository;
        }

        [HttpGet("/api/contribuinte/obtercontribuintes")]
        public ActionResult<IEnumerable<Contribuinte>> ObterTodos()
        {
            var contribuintes = _contribuinteRepository.ObterTodos();
            return Created("/api/contribuinte/obtercontribuintes", contribuintes);
        }
           
        [HttpGet("/api/contribuinte/obtercontribuintecpf")]
        public ActionResult<Contribuinte> ObterContribuintePorCPF([FromBody]string cpf)
        {
            var contribuinte = _contribuinteRepository.ObterContribuintePorCPF(cpf);
            return Created("/api/contribuinte/obtercontribuintecpf", contribuinte);
        }

        [HttpPost("/api/contribuinte/criarcontribuinte")]
        public ActionResult<int> CriarContribuinte([FromBody]Contribuinte novoContribuinte)
        {
            var contribuinte = _contribuinteRepository.Adicionar(novoContribuinte);
            return Created("/api/contribuinte/criarcontribuinte", contribuinte);
        }
    }
}
