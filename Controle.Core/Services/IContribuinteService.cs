using System.Collections.Generic;
using System.Threading.Tasks;
using Controle.Models;

namespace Controle.Core.Services
{
    public interface IContribuinteService
    {
        Task<IList<Contribuinte>> ObterTodos();
    }
}
