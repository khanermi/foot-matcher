using ConsoleViewPresent;
using ConsoleViewPresent.Base;
using FootMatcher.Presentation.ViewInterfaces;
using FootMatcher.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.ConsoleApp.Views
{
    public abstract class View<TViewModel> : ConsoleRenderableView, IView<TViewModel>
        where TViewModel : ViewModel
    {
        private readonly TViewModel _viewModel;

        protected View(ConsoleViewRenderer renderer, TViewModel viewModel) : base(renderer)
        {
            _viewModel = viewModel;
        }

        public TViewModel ViewModel => _viewModel;
    }
}
