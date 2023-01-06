using ConsoleViewPresent;
using ConsoleViewPresent.Base;
using ConsoleViewPresent.Interfaces;
using FootMatcher.ConsoleApp.Views.StartMenu.Components;
using FootMatcher.Presentation.ViewEventArgs;
using FootMatcher.Presentation.ViewInterfaces;
using FootMatcher.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.ConsoleApp.Views.StartMenu
{
    public class StartMenuView : View<StartMenuViewModel>, IStartMenuView
    {
        public StartMenuView(ConsoleViewRenderer renderer, StartMenuViewModel viewModel) : base(renderer, viewModel)
        {
        }

        public event EventHandler GenerateDefaultSessionEvent;

        public override void ConfigureComponents()
        {
            var components = new List<ConsoleRenderableComponent>()
            {
                ConfigureExampleComponent(),
            };

            AddComponent(components);
        }


        private void OnExampleComponentGenerateDefaultSessionEvent(object sender, EventArgs e)
        {
            if (e is not OptionSelectedEventArgs eventArgs)
            {
                throw new InvalidCastException(nameof(OptionSelectedEventArgs));
            }

            GenerateDefaultSessionEvent?.Invoke(this, new GenerateDefaultSessionEventArgs());
        }

        private ExampleComponent ConfigureExampleComponent()
        {
            var description = $"Select an action:";
            
            var options = new List<Option>() 
            {
                new Option("1", "Generate default session", "generateDefaultSession", OnExampleComponentGenerateDefaultSessionEvent)
            };

            return new ExampleComponent(description, options);
        }

        public void SetGenerateDefaultSessionEventHandler(EventHandler eventHandler)
        {
            GenerateDefaultSessionEvent = eventHandler;
        }
    }
}
