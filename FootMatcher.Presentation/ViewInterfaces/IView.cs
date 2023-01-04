using FootMatcher.Presentation.ViewModels;

namespace FootMatcher.Presentation.ViewInterfaces
{
    public interface IView<TViewModel>
        where TViewModel : ViewModel
    {
        TViewModel ViewModel { get; }

        void Show();
    }
}
