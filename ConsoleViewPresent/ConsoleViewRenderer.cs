using ConsoleViewPresent.Base;
using ConsoleViewPresent.Interfaces;

namespace ConsoleViewPresent
{
    public class ConsoleViewRenderer
    {
        private IConsoleRenderableView _currentView;
        private IConsoleRenderableView _nextView;

        public IConsoleRenderableView NextView 
        {
            get => _nextView;
            set 
            {
                _nextView = value;
            }
        }

        public void Run()
        {
            while (_nextView != null)
            {
                _currentView = NextView;
                NextView = null;

                RenderCurrentView();
            }

            // Application end
        }

        private void RenderCurrentView()
        {
            _currentView.Render();
        }
    }
}