namespace ConsoleViewPresent.Interfaces
{
    public interface IConsoleRenderableView
    {
        void Render();

        void AddComponent(IConsoleRenderableComponent component);
        void AddComponent(IEnumerable<IConsoleRenderableComponent> components);
    }
}
