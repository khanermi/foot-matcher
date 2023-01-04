using ConsoleViewPresent.Interfaces;

namespace ConsoleViewPresent.Base
{
    public abstract class ConsoleRenderableView : IConsoleRenderableView
    {
        private readonly List<IConsoleRenderableComponent> _components;
        
        private readonly ConsoleViewRenderer _renderer;

        public ConsoleRenderableView(ConsoleViewRenderer renderer)
        {
            _renderer = renderer;

            _components = new List<IConsoleRenderableComponent>();
        }

        public abstract void ConfigureComponents();

        public void Show()
        {
            _renderer.NextView = this;
        }

        public virtual void ConfigureView()
        {
            ConfigureComponents();
        }

        public void Render() 
        {
            Console.Clear();

            ConfigureView();
            _components.ForEach(x => x.Render());
        }

        public void AddComponent(IConsoleRenderableComponent component)
        {
            _components.Add(component);
        }

        public void AddComponent(IEnumerable<IConsoleRenderableComponent> components)
        {
            _components.AddRange(components);
        }
    }
}
