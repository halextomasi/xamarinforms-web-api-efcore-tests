using Controle.Core.Services;
using Controle.Core.ViewModels.Base;
using Xamarin.Forms;

namespace Controle.Core
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            BuildDependencies();
            InitNavigation();
        }

        public void BuildDependencies()
        {
            ViewModelLocator.Instance.Build();
        }

        private async void InitNavigation()
        {
            var navigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
            await navigationService.InitializeAsync();
        }

        protected override void OnStart()
        {

        }
    }
}
