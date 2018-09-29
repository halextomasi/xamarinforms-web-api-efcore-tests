using Controle.API.Models;
using System.Collections.Generic;

namespace Controle.API.Repositories.Interfaces
{
    public interface IContribuinteRepository
    {
        int Adicionar(Contribuinte contribuinte);
        IEnumerable<Contribuinte> ObterTodos();
        Contribuinte ObterContribuintePorCPF(string cpf);
    }
}
