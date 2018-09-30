using System.Collections.Generic;
using System.Collections.ObjectModel;
using Controle.Models;

namespace Controle.Core.Extensions
{
    public static class ContribuinteExtension
    {
        public static ObservableCollection<Contribuinte> ToObservableCollection(
            this IList<Contribuinte> listaContribuinte)
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