using Microsoft.Extensions.DependencyInjection;

namespace FootMatcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection()
                .AddScoped<IConsoleLogger, ConsoleLogger>()
                .AddScoped<JustExecuter>();
            
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var executer = serviceProvider.GetService<JustExecuter>();

            if (executer == null)
            {
                throw new NullReferenceException("executer not found");
            }

            executer.Execute();
        }
    }
}