using ConsoleViewPresent.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleViewPresent.Base
{
    public class ConsoleRenderableComponent : IConsoleRenderableComponent
    {
        private readonly string _description;
        private readonly List<Option> _options;

        public ConsoleRenderableComponent(string description, List<Option> options)
        {
            _description = description ?? throw new ArgumentNullException(nameof(description));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public void Render()
        {
            Console.WriteLine($"{_description}");
            Console.WriteLine();

            foreach (var option in _options)
            {
                Console.WriteLine($"{option.Name}) {option.Value}");
            }
            Console.WriteLine();

            var selection = Console.ReadLine();

            var selectedOption = _options.FirstOrDefault(x => x.Name == selection);
            if (selectedOption == null)
            {
                throw new Exception($"Wrong input in component");
            }

            selectedOption.InvokeCallback(this, new OptionSelectedEventArgs()
            {
                SelectedOption = selectedOption
            });
        }
    }
}
