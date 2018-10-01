using System.Collections.Generic;
using System.Threading.Tasks;
using Controle.Core.Models;

namespace Controle.Core.Services
{
    public interface IContribuinteService
    {
        IEnumerable<Contribuinte> ObterTodos();
        bool AdicionarContribuinte(Contribuinte contribuinte);
    }
}
