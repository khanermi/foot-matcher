using FootMatcher.Presentation.Presenters;
using FootMatcher.Presentation.ViewModels;
using FootMatcher.Presentation.ViewSwitch.PresenterCreators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.Presentation.ViewSwitch
{
    public class ViewSwitcher
    {
        private readonly SessionDetailsPresenterCreator _sessionDetailsPresenterCreator;
        private readonly StartMenuPresenterCreator _startMenuPresenterCreator;

        public ViewSwitcher(SessionDetailsPresenterCreator sessionDetailsPresenter,
            StartMenuPresenterCreator startMenuPresenterCreator)
        {
            _sessionDetailsPresenterCreator = sessionDetailsPresenter ?? throw new ArgumentNullException(nameof(sessionDetailsPresenter));
            _startMenuPresenterCreator = startMenuPresenterCreator ?? throw new ArgumentNullException(nameof(startMenuPresenterCreator));
        }

        public void ShowSessionDetails(SessionDetailsViewModel viewModel)
        {
            var presenter = new SessionDetailsPresenter(_sessionDetailsPresenterCreator.View,
                this);

            presenter.ShowView(viewModel);
        }

        public void ShowStartMenu(StartMenuViewModel viewModel)
        {
            var presenter = new StartMenuPresenter(_startMenuPresenterCreator.View,
                this,
                _startMenuPresenterCreator.SessionBusinessService);

            presenter.ShowView(viewModel);
        }
    }
}
