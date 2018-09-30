using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Controle.Core.Extensions;
using Controle.Core.Services;
using Controle.Core.ViewModels.Base;
using Controle.Models.Classes;
using Realms;
using Xamarin.Forms;

namespace Controle.Core.ViewModels
{
    public class ListaViewModel : ViewModelBase, IHandleViewAppearing
    {
        private readonly IContribuinteService _contribuinteService;

        public double ValorSalarioMinimo { get; set; }
        public ObservableCollection<Contribuinte> _contribuintes;
        
        public ObservableCollection<Contribuinte> Contribuintes 
        {
            get { return _contribuintes; }
            set
            {
                _contribuintes = value;
                OnPropertyChanged();
            }
        }
        
        public ListaViewModel(IContribuinteService contribuinteService) 
            : base("Lista")
        {
            _contribuinteService = contribuinteService;
        }

        public async Task OnViewAppearingAsync(VisualElement view)
        {
            ValorSalarioMinimo = 800;
            
            var realmDb = Realm.GetInstance();
            var listaContribuintes = await _contribuinteService.ObterTodos();
            
            //SE O REALM JA ESTIVER COM BASE DE DADOS
            //   E O TAMANHO DA PESQUISA FOR DIFERENTE DA QUE O REALM TEM
            // ELE ATUALIZA O REALM E ATUALIZA O OBSERVABLE COLLECTION
            
            if (realmDb.All<Contribuinte>().Count() != listaContribuintes.Count)
            {
                realmDb.RemoveAll<Contribuinte>();

                foreach (var contribuinte in listaContribuintes)
                {
                    realmDb.Write(() =>
                    {
                        realmDb.Add(contribuinte);
                    });
                }
            }
        }
    }
}
