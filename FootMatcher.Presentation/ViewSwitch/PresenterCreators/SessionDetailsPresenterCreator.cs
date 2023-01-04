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
    public class SessionDetailsPresenterCreator : PresenterCreator<SessionDetailsPresenter, ISessionDetailsView, SessionDetailsViewModel>
    {
        public SessionDetailsPresenterCreator(ISessionDetailsView view) : base(view)
        {
        }
    }
}
