using Controle.API.Models;
using Controle.API.Models.Context;
using Controle.API.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Controle.API.Repositories
{
    public class ContribuinteRepository : IContribuinteRepository
    {
        private ApplicationContext _context;

        public ContribuinteRepository(ApplicationContext ApplicationContext)
        {
            _context = ApplicationContext;
        }

        public int Adicionar(Contribuinte contribuinte)
        {
            _context.Contribuintes.Add(contribuinte);
            return _context.SaveChanges();
        }

        public IEnumerable<Contribuinte> ObterTodos()
        {
            return _context.Contribuintes.ToList();
        }

        public Contribuinte ObterContribuintePorCPF(string cpf)
        {
            return _context.Contribuintes.FirstOrDefault(b => b.CPF == cpf);
        }
    }
}