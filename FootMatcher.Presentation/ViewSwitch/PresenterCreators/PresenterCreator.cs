using FootMatcher.Presentation.Presenters;
using FootMatcher.Presentation.ViewInterfaces;
using FootMatcher.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.Presentation.ViewSwitch.PresenterCreators
{
    public abstract class PresenterCreator<TPresenter, TView, TViewModel>
        where TPresenter: Presenter<TView, TViewModel>
        where TView : IView<TViewModel>
        where TViewModel : ViewModel
    {
        protected PresenterCreator(TView view)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
        }

        public TView View { get; }
    }
}
