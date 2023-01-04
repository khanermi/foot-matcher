using FootMatcher.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.Presentation.ViewInterfaces
{
    public interface IStartMenuView : IView<StartMenuViewModel>
    {
        // property of viewmodel if pass info to the view

        // events if notify presenter about changes
        event EventHandler GenerateDefaultSessionEvent;
    }
}
