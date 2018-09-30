using System.Threading.Tasks;
using Controle.Core.Services;
using Controle.Core.ViewModels.Base;
using Controle.Models.Classes;
using Xamarin.Forms;

namespace Controle.Core.ViewModels
{
    public class CadastroViewModel : ViewModelBase, IHandleViewAppearing
    {
        private Contribuinte _contribuinte;

        private readonly IContribuinteService _contribuinteService;
        
        public CadastroViewModel(IContribuinteService contribuinteService)
            : base ("Cadastro")
        {
            _contribuinteService = contribuinteService;
        }
        
        public Contribuinte Contribuinte
        {
            get { return _contribuinte; }
            set
            {
                _contribuinte = value;
                OnPropertyChanged();
            }
        }

        public Task OnViewAppearingAsync(VisualElement view)
        {
            return Task.CompletedTask;
        }
    }
}
