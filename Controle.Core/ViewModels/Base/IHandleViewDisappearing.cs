using System.Threading.Tasks;
using Xamarin.Forms;

namespace Controle.Core.ViewModels.Base
{
    public interface IHandleViewDisappearing
    {
        Task OnViewDisappearingAsync(VisualElement view);
    }
}
