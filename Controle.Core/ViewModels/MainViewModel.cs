using System;
using Controle.Core.ViewModels.Base;

namespace Controle.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        CadastroViewModel _cadastroViewModel;
        ListaViewModel _listaViewModel;

        public CadastroViewModel CadastroViewModel
        {
            get { return _cadastroViewModel; }
            set
            {
                _cadastroViewModel = value;
                OnPropertyChanged();
            }
        }

        public ListaViewModel ListaViewModel
        {
            get { return _listaViewModel; }
            set
            {
                _listaViewModel = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(CadastroViewModel cadastroViewModel,
            ListaViewModel listaViewModel)
        {
            _cadastroViewModel = cadastroViewModel;
            _listaViewModel = listaViewModel;
        }
    }

}
