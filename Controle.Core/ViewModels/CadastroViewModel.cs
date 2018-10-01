using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Controle.Core.Services;
using Controle.Core.ViewModels.Base;
using Controle.Models.Classes;
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
                try
                {
                    if (ValidaPreenchimentoCampos())
                    {
                        contribuinteService.AdicionarContribuinte(_contribuinte);

                        _dialogService.AlertAsync("Status", "Dados do investidor alterados com sucesso!", "Ok");
                    }
                }
                catch (Exception ex)
                {
                    var mensagem = "Não foi possível alterar os dados do investidor. Verifique sua conexão! \n Detalhe: " +
                               ex.Message;
                    
                    _dialogService.AlertAsync("Status", mensagem, "Ok");
                }
            });
        }

        public bool ValidaPreenchimentoCampos()
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

        public Task OnViewAppearingAsync(VisualElement view)
        {
            return Task.FromResult(true);
        }
    }
}