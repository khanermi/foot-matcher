using FootMatcher.Models.Models;
using FootMatcher.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.Presentation.ViewInterfaces
{
    public interface ISessionDetailsView : IView<SessionDetailsViewModel>
    {
        event EventHandler ExitToStartMenuEvent;
    }
}
