using System.Threading.Tasks;
using System.Windows.Input;
using Controle.Core.Models;
using Controle.Core.Services;
using Controle.Core.ViewModels.Base;
using Xamarin.Forms;

namespace Controle.Core.ViewModels
{
    public class CadastroViewModel : ViewModelBase, IHandleViewAppearing
    {
        private readonly IDialogService _dialogService;
        private readonly IContribuinteService _contribuinteService;
        
        public ICommand GravarClickedCommand { get; private set; }
        
        private Contribuinte _contribuinte;
        public Contribuinte Contribuinte
        {
            get { return _contribuinte; }
            set
            {
                _contribuinte = value;
                OnPropertyChanged();
            }
        }

        public CadastroViewModel(IDialogService dialogService,
                                 IContribuinteService contribuinteService)
            : base("Cadastro")
        {
            _dialogService = dialogService;
            _contribuinteService = contribuinteService;
            
            Contribuinte = new Contribuinte();

            GravarClickedCommand = new Command(() =>
            {
                if (ValidaPreenchimentoCampos())
                {
                    if (contribuinteService.AdicionarContribuinte(_contribuinte))
                    {
                        _dialogService.AlertAsync("Status", "Contribuinte cadastrado com sucesso!", "Ok");
                    }
                    else
                    {
                        _dialogService.AlertAsync("Status", "Não foi possível cadastrar o novo contribuinte. Verifique sua conexão!", "Ok");
                    }
                    
                    Contribuinte = new Contribuinte();
                }
            });
        }

        public Task OnViewAppearingAsync(VisualElement view)
        {
            return Task.FromResult(true);
        }
        
        private bool ValidaPreenchimentoCampos()
        {
            if (Contribuinte.CPF.Length != 14) //Com a máscara.
            {
                _dialogService.AlertAsync("Campo Obrigatório", "Favor informar um CPF válido.", "Ok");
                return false;
            }
            
            if (Contribuinte.Nome.Length == 0)
            {
                _dialogService.AlertAsync("Campo Obrigatório", "Favor preencher o campo Nome.", "Ok");
                return false;
            }

            return true;
        }
    }
}