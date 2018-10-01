using System.Collections.Generic;
using System.Threading.Tasks;
using Controle.Models.Classes;

namespace Controle.Core.Services
{
    public interface IContribuinteService
    {
        Task<IList<Contribuinte>> ObterTodos();
        bool AdicionarContribuinte(Contribuinte contribuinte);
    }
}
