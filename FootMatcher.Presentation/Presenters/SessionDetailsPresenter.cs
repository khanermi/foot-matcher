using FootMatcher.BusinessServices.Interfaces.Interfaces;
using FootMatcher.Presentation.ViewEventArgs;
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
    public class SessionDetailsPresenter : Presenter<ISessionDetailsView, SessionDetailsViewModel>
    {
        public SessionDetailsPresenter(ISessionDetailsView view,
            ViewSwitcher viewSwitcher) : base(view, viewSwitcher)
        {
            //_view.ExitToStartMenuEvent += OnExitToStartMenuEvent;
            _view.SetExitToStartMenuEventHandler(OnExitToStartMenuEvent);
        }

        protected override void PopulateView(SessionDetailsViewModel viewModel)
        {
            base.PopulateView(viewModel);

            _view.ViewModel.Session = viewModel.Session;
        }

        private void OnExitToStartMenuEvent(object sender, EventArgs e)
        {
            if (e is not ExitToStartMenuEventArgs eventArgs)
            {
                throw new InvalidCastException(nameof(ExitToStartMenuEventArgs));
            }

            _viewSwitcher.ShowStartMenu(new StartMenuViewModel());
        }
    }
}
