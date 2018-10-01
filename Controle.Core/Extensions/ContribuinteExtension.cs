using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Controle.Core.Models;

namespace Controle.Core.Extensions
{
    public static class ContribuinteExtension
    {
        public static ObservableCollection<Contribuinte> ToObservableCollection(
            this IEnumerable<Contribuinte> listaContribuinte)
        {
            var observableCollection = new ObservableCollection<Contribuinte>();
            
            foreach (var contribuinte in listaContribuinte)
            {
                observableCollection.Add(contribuinte);
            }

            return observableCollection;
        }
        
        public static ObservableCollection<Contribuinte> ToObservableCollection(
            this IQueryable<Contribuinte> listaContribuinte)
        {
            var observableCollection = new ObservableCollection<Contribuinte>();
            
            foreach (var contribuinte in listaContribuinte)
            {
                observableCollection.Add(contribuinte);
            }

            return observableCollection;
        }
    }
}