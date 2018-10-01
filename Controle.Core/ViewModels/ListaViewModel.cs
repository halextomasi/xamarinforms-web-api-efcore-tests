using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Controle.Core.Extensions;
using Controle.Core.Models;
using Controle.Core.Services;
using Controle.Core.ViewModels.Base;
using Xamarin.Forms;

namespace Controle.Core.ViewModels
{
    public class ListaViewModel : ViewModelBase, IHandleViewAppearing
    {
        private readonly IDialogService _dialogService;
        private readonly IContribuinteService _contribuinteService;

        public ICommand AtualizarClickedCommand { get; private set; }
        
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

        public ListaViewModel(IDialogService dialogService,
            IContribuinteService contribuinteService)
            : base("Lista")
        {
            _dialogService = dialogService;
            _contribuinteService = contribuinteService;
            
            ValorSalarioMinimo = 800.00;

            AtualizaLista();
            
            AtualizarClickedCommand = new Command(() =>
            {
                if (ValidaPreenchimentoCampos())
                {
                    AtualizaLista();

                    _dialogService.AlertAsync("Status", "Valor do salário mínimo foi atualizado!", "Ok");
                }
            });
        }

        public Task OnViewAppearingAsync(VisualElement view)
        {
            return Task.FromResult(true);
        }

        private void AtualizaLista()
        {
            var listaContribuintes = _contribuinteService.ObterTodos();
            _contribuintes = listaContribuintes.ToObservableCollection();

            foreach (var contribuinte in _contribuintes)
            {
                contribuinte.ImpostoDeRenda = RetornaValorImpostoDeRenda(contribuinte);
            }

            Contribuintes = _contribuintes.OrderBy(p => p.ImpostoDeRenda) 
                                                    .ThenBy(p => p.Nome)
                                                    .ToObservableCollection();
        }

        private string RetornaValorImpostoDeRenda(Contribuinte contribuinte)
        {
            var rendaLiquida = contribuinte.RendaBrutaMensal -
                               (contribuinte.NumeroDependentes * (ValorSalarioMinimo * 0.05));

            if (rendaLiquida <= ValorSalarioMinimo * 2)
            {
                //Isento
            }
            else if (rendaLiquida >= ValorSalarioMinimo * 2 && rendaLiquida <= ValorSalarioMinimo * 4)
            {
                rendaLiquida = rendaLiquida - (rendaLiquida * 0.75);
            }
            else if (rendaLiquida >= ValorSalarioMinimo * 4 && rendaLiquida <= ValorSalarioMinimo * 5)
            {
                rendaLiquida = rendaLiquida - (rendaLiquida * 0.15);
            }
            else if (rendaLiquida >= ValorSalarioMinimo * 5 && rendaLiquida <= ValorSalarioMinimo * 7)
            {
                rendaLiquida = rendaLiquida - (rendaLiquida * 0.225);
            }
            else if (rendaLiquida > ValorSalarioMinimo * 7)
            {
                rendaLiquida = rendaLiquida - (rendaLiquida * 0.275);
            }

            return "R$" + rendaLiquida.ToString(("######.00"));
        }

        private bool ValidaPreenchimentoCampos()
        {
            if (ValorSalarioMinimo.ToString() == string.Empty
                || ValorSalarioMinimo <= 0) //Com a máscara.
            {
                _dialogService.AlertAsync("Campo Obrigatório", "Favor informar um valor válido.", "Ok");
                return false;
            }

            return true;
        }
    }
}