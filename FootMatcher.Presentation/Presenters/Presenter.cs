using FootMatcher.Presentation.ViewInterfaces;
using FootMatcher.Presentation.ViewModels;
using FootMatcher.Presentation.ViewSwitch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.Presentation.Presenters
{
    public abstract class Presenter<TView, TViewModel>
        where TView : IView<TViewModel>
        where TViewModel : ViewModel
    {
        protected readonly TView _view;
        protected readonly ViewSwitcher _viewSwitcher;

        public Presenter(TView view,
            ViewSwitcher viewSwitcher)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _viewSwitcher = viewSwitcher ?? throw new ArgumentNullException(nameof(viewSwitcher));
        }

        public void ShowView(TViewModel viewModel)
        {
            PopulateView(viewModel);

            _view.Show();
        }

        protected virtual void PopulateView(TViewModel viewModel)
        {
        }
    }
}
