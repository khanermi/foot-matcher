using FootMatcher.BusinessServices.Interfaces.Interfaces;
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
    public class StartMenuPresenterCreator : PresenterCreator<StartMenuPresenter, IStartMenuView, StartMenuViewModel>
    {
        public StartMenuPresenterCreator(IStartMenuView view,
            ISessionBusinessService sessionBusinessService) : base(view)
        {
            SessionBusinessService = sessionBusinessService ?? throw new ArgumentNullException(nameof(sessionBusinessService));
        }

        public ISessionBusinessService SessionBusinessService { get; }
    }
}
