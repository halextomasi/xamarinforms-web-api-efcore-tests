using System.Collections.Generic;
using Controle.Core.Models;

namespace Controle.Core.Services
{
    public interface IContribuinteService
    {
        IEnumerable<Contribuinte> ObterTodos();
        bool AdicionarContribuinte(Contribuinte contribuinte);
    }
}
