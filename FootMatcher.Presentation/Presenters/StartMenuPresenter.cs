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
    public class StartMenuPresenter : Presenter<IStartMenuView, StartMenuViewModel>
    {
        private readonly ISessionBusinessService _sessionBusinessService;

        public StartMenuPresenter(IStartMenuView view,
            ViewSwitcher viewSwitcher,
            ISessionBusinessService sessionBusinessService) : base(view, viewSwitcher)
        {
            _sessionBusinessService = sessionBusinessService ?? throw new ArgumentNullException(nameof(sessionBusinessService));

            _view.GenerateDefaultSessionEvent += OnGenerateDefaultSessionEvent;
        }

        private void GenerateRandomMatchWithRandomStarsEvent(object sender, EventArgs e)
        {
            if (e is not GenerateRandomMatchWithRandomStarsEventArgs eventArgs)
            {
                throw new InvalidCastException(nameof(GenerateRandomMatchWithRandomStarsEventArgs));
            }
        }

        private void OnGenerateDefaultSessionEvent(object sender, EventArgs e)
        {
            if (e is not GenerateDefaultSessionEventArgs eventArgs)
            {
                throw new InvalidCastException(nameof(GenerateDefaultSessionEventArgs));
            }

            var session = _sessionBusinessService.GenerateDefaultSession();

            var sessionDetailsViewModel = new SessionDetailsViewModel()
            {
                Session = session,
            };

            _viewSwitcher.ShowSessionDetails(sessionDetailsViewModel);
        }
    }
}
