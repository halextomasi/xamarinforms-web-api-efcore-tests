using System.Threading.Tasks;
using Xamarin.Forms;

namespace Controle.Core.ViewModels.Base
{
    public interface IHandleViewAppearing
    {
        Task OnViewAppearingAsync(VisualElement view);
    }
}
