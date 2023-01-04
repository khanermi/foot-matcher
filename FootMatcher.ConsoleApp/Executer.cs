using ConsoleViewPresent;
using FootMatcher.Presentation.Presenters;
using FootMatcher.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher
{
    public class Executer
    {
        private readonly StartMenuPresenter _startMenuPresenter;
        private readonly ConsoleViewRenderer _renderer;

        public Executer(StartMenuPresenter startMenuPresenter, ConsoleViewRenderer renderer)
        {
            _startMenuPresenter = startMenuPresenter;
            _renderer = renderer;

            _startMenuPresenter.ShowView(new StartMenuViewModel());
        }

        public void Execute()
        {
            _renderer.Run();
        }
    }
}
