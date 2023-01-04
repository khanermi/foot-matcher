using ConsoleViewPresent;
using ConsoleViewPresent.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.ConsoleApp.Views.StartMenu.Components
{
    public class ExampleComponent : ConsoleRenderableComponent
    {
        public ExampleComponent(string description, List<Option> options) : base(description, options)
        {
        }
    }
}
